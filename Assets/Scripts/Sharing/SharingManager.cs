using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine.VR.WSA;
using UnityEngine.VR.WSA.Sharing;
using UnityEngine.VR.WSA.Persistence;
using HoloToolkit.Unity;
#if UNITY_UWP && !UNITY_EDITOR
using System.Threading.Tasks;
#endif

public class SharingManager : Singleton<SharingManager> 
{

    #region Variables
    
    /// <summary>
    /// WorldAnchorStore
    /// </summary>
    private WorldAnchorStore _anchorStore;
    /// <summary>
    /// Show Detailed Information for sharing services.
    /// </summary>
    [Tooltip("Show Detailed Information for p2p sharing services.")]
    public bool ShowDetailedLogs = false;

    //private Dictionary<string, WorldAnchor> _anchors = new Dictionary<string, WorldAnchor>();
    /// <summary>
    /// The datablob of the anchor.
    /// </summary>
    private List<byte> exportingAnchorBytes = new List<byte>();
    /// <summary>
    /// Sometimes we'll see a really small anchor blob get generated.
    /// These tend to not work, so we have a minimum trustworthy size.
    /// </summary>
    private const uint MinTrustworthySerializedAnchorDataSize = 100000;
    /// <summary>
    /// Keeps track of the name of the anchor we are exporting.
    /// </summary>
    private string exportingAnchorName;
    /// <summary>
    /// Status of the sharing service 
    /// </summary>
    public SharingServiceState CurrentState = SharingServiceState.Start;
#if UNITY_UWP && !UNITY_EDITOR
    /// <summary>
    /// BluetoothLE manager
    /// </summary>
    private BluetoothLEManager bluetoothLEManager;
#endif
    #endregion

    private void Start()
    {
        WorldAnchorStore.GetAsync(WorldAnchorStoreLoaded);
    }
    private void WorldAnchorStoreLoaded(WorldAnchorStore store)
    {
        _anchorStore = store;
    }

    private void Update()
    {

    }

    public void SendEvent(byte[] bits)
    {
#if UNITY_UWP && !UNITY_EDITOR
        var Task = this.bluetoothLEManager.SendEventAsync(bits);
#endif
    }


    public void TransferAnchor(WorldAnchor worldAnchor)
    {
        if (worldAnchor == null) return;

        exportingAnchorName = worldAnchor.gameObject.name; //Guid.NewGuid().ToString();
        _anchorStore.Delete(exportingAnchorName);

        if (_anchorStore.Save(exportingAnchorName, worldAnchor))
        {
            exportingAnchorBytes.Clear();
            var batch = new WorldAnchorTransferBatch();
            batch.AddWorldAnchor(exportingAnchorName, worldAnchor);
            WorldAnchorTransferBatch.ExportAsync(batch, OnDataAvailable, OnDataExported);
        }
    }

    private void OnDataAvailable(byte[] data)
    {
        exportingAnchorBytes.AddRange(data);
    }

    private void OnDataExported(SerializationCompletionReason reason)
    {
        if (reason == SerializationCompletionReason.Succeeded && exportingAnchorBytes.Count() > MinTrustworthySerializedAnchorDataSize)
        {
            // Should inform the Client everything worked?
#if UNITY_UWP && !UNITY_EDITOR

            if (ShowDetailedLogs)
            {
                Debug.Log("Anchor Manager: Uploading anchor: " + exportingAnchorName);
            }

            var task = this.bluetoothLEManager.SendWorldAnchorAsync(exportingAnchorBytes.ToArray());
#endif
        }
        else
        {
            // Something went wrong...
            if (ShowDetailedLogs)
            {
                Debug.Log("Failed to import: " + exportingAnchorName);
            }
        }
    }

    private void ReceiveNewAnchor(byte[] rawData)
    {
        WorldAnchorTransferBatch.ImportAsync(rawData, OnReceiveCompleted);
    }

    private void OnReceiveCompleted(SerializationCompletionReason reason, WorldAnchorTransferBatch batch)
    {
        if (reason != SerializationCompletionReason.Succeeded)
        {
            // Oops..
            Debug.Log("Failed to import: " + reason.ToString());
            return;
        }

        var allIds = batch.GetAllIds();
        foreach (var id in allIds)
        {
            GameObject myGameObject = GameObject.Find(id);
            var anchor = batch.LockObject(id, myGameObject);

            //_anchors.Add(id, anchor);
        }
    }

    public void OnAdvertise()
    {

#if UNITY_UWP && !UNITY_EDITOR
        var Task = OnInitialise(true);
#endif
    }
    public void OnConnect()
    {
#if UNITY_UWP && !UNITY_EDITOR
        var Task = OnInitialise(false);
#endif
    }

    void OutputBluetoothConnectionMessage(string info)
    {
        GameObject myTextOjbect = GameObject.FindGameObjectWithTag("BluetoothMessage");
        Text myText = myTextOjbect.GetComponent<Text>();
        myText.text = info;
    }

#if UNITY_UWP && !UNITY_EDITOR

    async Task OnInitialise(bool advertise = true)
    {
        if (this.bluetoothLEManager == null)
        {
            this.bluetoothLEManager = new BluetoothLEManager();
        }

        if (advertise)
        {
            await this.bluetoothLEManager.SetupBluetoothAdvertisement();
        }
        else
        {
            await this.bluetoothLEManager.SetupBluetoothWatcher();
        }

        if (this.bluetoothLEManager.isConnected)
        {
            if (advertise)
            {
                OutputBluetoothConnectionMessage("[Broadcaster] Connection has been established. Enjoy the sharing!");
            }
            else
            {
                OutputBluetoothConnectionMessage("[Watcher] Connection has been established. Enjoy the sharing!");
            }

            CurrentState = SharingServiceState.ConnectionEstablished;
              
            await this.bluetoothLEManager.ReadAndDispatchMessageLoopAsync(this.MessageHandler);
        }
    }

    public bool IsExportEventEnabled
    {
        get
        {
            return CurrentState != SharingServiceState.ReadyToImportEventHandler;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="messageType"></param>
    /// <param name="messageBody"></param>
    void MessageHandler(TransferMessageType messageType, object messageBody)
    {
        switch (messageType)
        {
            case TransferMessageType.WorldAnchor:
                CurrentState = SharingServiceState.ReadyToImportChangedAnchor;
                ReceiveNewAnchor((byte[])messageBody);
                break;
            case TransferMessageType.Event:
                CurrentState = SharingServiceState.ReadyToImportEventHandler;
                var rawData = System.Text.Encoding.UTF8.GetString((byte[])messageBody);

                var items = rawData.Split('|');
                switch (items[0])
                {
                    case "SelectStock":
                        var panel = GameObject.Find("No1Panel");
                        var controller = panel.GetComponentInChildren<No1PanelController>();

                        controller.SelectStock(items[1], items[2], items[3], Convert.ToBoolean(items[4]), items[5], items[6], items[7]);
                        
                        break;
                    case "ShowNextPanel":
                        var panel2 = GameObject.Find("No2Panel");
                        var controller2 = panel2.GetComponentInChildren<No2PanelController>();

                        controller2.ShowNextPanel();
                        break;
                }
                
                break;

        }

        CurrentState = SharingServiceState.ConnectionEstablished;

        //if (messageType == TransferMessageType.String)
        //{
        //    OutputDebugInfo(messageBody.ToString());
        //}
        //else if (messageType == TransferMessageType.Buffer)
        //{
        //    ReceiveNewAnchor((byte[])messageBody);
        //}
    }

#endif
}

public enum TransferMessageType : byte
{
    WorldAnchor,
    Event,
    Text,
    Buffer,
    String,
    SerializedObject
}

/// <summary>
/// Enum to track the transfer progress
/// </summary>
public enum SharingServiceState
{
    Start,
    // Connection has been established
    ConnectionEstablished,
    // Anchor need to be exported
    ReadyToExportInitialAnchor,
    // Ready for importing event
    ReadyToImportChangedAnchor,
    // Ready for importing event
    ReadyToImportEventHandler,
}