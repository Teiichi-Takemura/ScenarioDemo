using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
#if UNITY_UWP && !UNITY_EDITOR
//using MyUWPLibraryForUnity;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Storage.Streams;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Networking.Connectivity;
using MessageTypePair = System.Tuple<TransferMessageType, object>;
#endif


public class BluetoothLEManager
{
    public bool isConnected = false;

#if UNITY_UWP && !UNITY_EDITOR
    BluetoothLEAdvertisementPublisher _publisher;
    BluetoothLEAdvertisementWatcher _watcher;
    TaskCompletionSource<bool> _connectionMadeTask;
    StreamSocketListener _socketListener;
    StreamSocket _socket;
    public BluetoothLEManager()
    { }

    /// <summary>
    /// Start to broadcast a Bluetooth advertisement.
    /// </summary>
    /// <returns></returns>
    public async Task SetupBluetoothAdvertisement()
    {
        var myIpAddress = GetMyIPAddress();
        OutputBluetoothConnectionMessage("Broadcasting from " + myIpAddress);

        this._connectionMadeTask = new TaskCompletionSource<bool>();

        this._socketListener = new StreamSocketListener();
        await this._socketListener.BindEndpointAsync(
            new HostName(myIpAddress), "8000");

        this._socketListener.ConnectionReceived += OnConnectionReceived;

        _publisher = new BluetoothLEAdvertisementPublisher();

        var manufactureData = new BluetoothLEManufacturerData();
        manufactureData.CompanyId = 0xFFFE;
        
        manufactureData.Data = WriteToBuffer(
            IPAddress.Parse(myIpAddress), 
            8000);

        _publisher.Advertisement.ManufacturerData.Add(manufactureData);
        _publisher.Start();

        await Task.WhenAny(this._connectionMadeTask.Task, Task.Delay(-1));
    }

    /// <summary>
    /// Connection with another device has been established.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    void OnConnectionReceived(
      StreamSocketListener sender,
      StreamSocketListenerConnectionReceivedEventArgs args)
    {
        // TODO: Can't get gameobjet here.
        //OutputBluetoothConnectionMessage("Connection has been established with" + args.Socket.Information.RemoteHostName);

        // Get the StreamSocket
        this._socket = args.Socket;
        // Stop all Bluetooth broadcasting or watching
        StopBroadcastingOrWatching();
        
        // flag success in connection
        isConnected = true;
        this._connectionMadeTask.SetResult(true);
    }

    /// <summary>
    /// Get local ip address.
    /// </summary>
    /// <returns>local ip address</returns>
    string GetMyIPAddress()
    {
        var icp = NetworkInformation.GetInternetConnectionProfile();
        if (icp == null)
        {
            return string.Empty;
        }

        var adapter = icp.NetworkAdapter;
        if (adapter == null)
        {
            return string.Empty;
        }

        var hostname = NetworkInformation.GetHostNames().FirstOrDefault(_ =>
            _.IPInformation?.NetworkAdapter != null &&
            _.Type == HostNameType.Ipv4 &&
            _.IPInformation.NetworkAdapter.NetworkAdapterId == icp.NetworkAdapter.NetworkAdapterId);

        return hostname.CanonicalName;
    }

    /// <summary>
    /// Start to watch a bluetooth advertisement
    /// </summary>
    /// <returns></returns>
    public async Task SetupBluetoothWatcher()
    {
        this._connectionMadeTask = new TaskCompletionSource<bool>();

        _watcher = new BluetoothLEAdvertisementWatcher();
        _watcher.Received += BluetoothWatcher_Connected;

        var manufacturerData = new BluetoothLEManufacturerData();
        manufacturerData.CompanyId = 0xFFFE;
        _watcher.AdvertisementFilter.Advertisement.ManufacturerData.Add(manufacturerData);
        _watcher.Start();

        await Task.WhenAny(this._connectionMadeTask.Task, Task.Delay(-1));
    }
    
    /// <summary>
    /// Received broadcasting data. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    async void BluetoothWatcher_Connected(BluetoothLEAdvertisementWatcher sender,
        BluetoothLEAdvertisementReceivedEventArgs args)
    {
        // Stop all Bluetooth broadcasting or watching
        StopBroadcastingOrWatching();

        // Get the payload of advertisement
        var item = args.Advertisement.GetManufacturerDataByCompanyId(0xFFFE);
        var advertisement = ReadFromBuffer(item.FirstOrDefault().Data);

        try
        {
            this._socket = new StreamSocket();
            // Connect to the broadcasting peer.
            await this._socket.ConnectAsync(
              new EndpointPair(
                null,
                string.Empty,
                new HostName(advertisement.IP.ToString()),
                advertisement.Port.ToString()));
            
            // flag success in connection
            isConnected = true;
            this._connectionMadeTask.SetResult(true);
        }
        catch
        {
            this._socket.Dispose();
            this._socket = null;

            isConnected = false;
            this._connectionMadeTask.SetResult(false);
        }
    }

    /// <summary>
    /// Write hostname and port to buffer
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="port"></param>
    /// <returns></returns>
    IBuffer WriteToBuffer(IPAddress ip, ushort port)
    {
        DataWriter writer = new DataWriter();

        var bits = ip.GetAddressBytes();
        writer.WriteUInt16((ushort)bits.Length);
        writer.WriteBytes(bits);
        writer.WriteUInt16(port);
        return (writer.DetachBuffer());
    }

    /// <summary>
    /// Read remote hostname and port from datasection buffer.
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static SocketAdvertisement ReadFromBuffer(IBuffer buffer)
    {
        SocketAdvertisement returnValue = new SocketAdvertisement();

        var dataReader = DataReader.FromBuffer(buffer);

        var bitLength = dataReader.ReadUInt16();
        var bits = new byte[bitLength];
        dataReader.ReadBytes(bits);
        returnValue.IP = new IPAddress(bits);
        returnValue.Port = dataReader.ReadUInt16();
        return (returnValue);
    }

    /// <summary>
    /// Stop all Bluetooth broadcasting and watching
    /// </summary>
    void StopBroadcastingOrWatching()
    {
        if (_publisher != null)
        {
            _publisher.Stop();
            _publisher = null;
        }

        if (_watcher != null)
        {
            _watcher.Stop();
            _watcher = null;
        }

    }

    void OutputBluetoothConnectionMessage(string info)
    {
        GameObject myTextOjbect = GameObject.FindGameObjectWithTag("BluetoothMessage");
        if (myTextOjbect == null) return;
        Text myText = myTextOjbect.GetComponent<Text>();
        myText.text = info;
    }

    /// <summary>
    /// Send string message
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task SendStringMessageAsync(string data)
    {
        var bits = UTF8Encoding.UTF8.GetBytes(data);
        await this.SendBytesAsync(TransferMessageType.String, bits);
    }

    public async Task SendBytesAsync(byte[] bits)
    {
        await this.SendBytesAsync(TransferMessageType.Buffer, bits);
    }

    public async Task SendWorldAnchorAsync(byte[] bits)
    {
        await this.SendBytesAsync(TransferMessageType.WorldAnchor, bits);
    }

    public async Task SendEventAsync(byte[] bits)
    {
        await this.SendBytesAsync(TransferMessageType.Event, bits);
    }

    /// <summary>
    /// Send data to another side.
    /// </summary>
    /// <param name="messageType"></param>
    /// <param name="bits"></param>
    /// <returns></returns>
    async Task SendBytesAsync(TransferMessageType messageType, byte[] bits)
    {
        await this.SendAsync(
          messageType,
          bits.Length,
          async () =>
          {
              await this._socket.OutputStream.WriteAsync(bits.AsBuffer());
          }
        );
    }

    /// <summary>
    /// SendAsync
    /// </summary>
    /// <param name="messageType"></param>
    /// <param name="length"></param>
    /// <param name="writeBitsAsync"></param>
    /// <returns></returns>
    async Task SendAsync(TransferMessageType messageType, int length, Func<Task> writeBitsAsync)
    {
        if (this._socket == null)
        {
            throw new InvalidOperationException("Socket not connected");
        }
        var data = BitConverter.GetBytes(length);

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(data);
        }
        await this._socket.OutputStream.WriteAsync(data.AsBuffer());

        await writeBitsAsync();

        data = new byte[] { (byte)messageType };
        await this._socket.OutputStream.WriteAsync(data.AsBuffer());

        await this._socket.OutputStream.FlushAsync();
    }

    /// <summary>
    /// Read data from input stream
    /// </summary>
    /// <returns></returns>
    public async Task<MessageTypePair> ReadMessageAsync()
    {
        // TODO: lots of allocations of potentially large size, might
        // be better to allocate some big buffer and keep re-using it?
        byte[] bits = new byte[Marshal.SizeOf<int>()];

        await this._socket.InputStream.ReadAsync(bits.AsBuffer(),
          (uint)bits.Length, InputStreamOptions.None);

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bits);
        }

        int size = BitConverter.ToInt32(bits, 0);

        bits = new byte[size + 1];

        await this._socket.InputStream.ReadAsync(bits.AsBuffer(),
          (uint)bits.Length, InputStreamOptions.None);

        var messageType = (TransferMessageType)bits[bits.Length - 1];
        var returnValue = (object)null;

        switch (messageType)
        {
            case TransferMessageType.WorldAnchor:
            case TransferMessageType.Event:
            case TransferMessageType.Buffer:
                Array.Resize<byte>(ref bits, bits.Length - 1);
                returnValue = bits;
                break;
            case TransferMessageType.String:
                returnValue = UTF8Encoding.UTF8.GetString(bits, 0, bits.Length - 1);
                break;
            case TransferMessageType.SerializedObject:
                //var strObject = UTF8Encoding.UTF8.GetString(bits, 0, bits.Length - 1);
                //returnValue = JsonConvert.DeserializeObject<MessageBase>(strObject, jsonSettings);
                break;
            default:
                break;
        }
        return (Tuple.Create(messageType, (object)returnValue));
    }

    /// <summary>
    /// Get messages from payload
    /// </summary>
    /// <param name="handler"></param>
    /// <returns></returns>
    public async Task ReadAndDispatchMessageLoopAsync(
      Action<TransferMessageType, object> handler)
    {
        while (true)
        {
            try
            {
                var msg = await this.ReadMessageAsync();
                handler(msg.Item1, msg.Item2);
            }
            catch
            {
                break;
            }
        }
    }

    /// <summary>
    /// Close stream socket
    /// </summary>
    public void Close()
    {
        if (this._socket != null)
        {
            this._socket.Dispose();
            this._socket = null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct SocketAdvertisement
    {
        public IPAddress IP;
        public ushort Port;
    }
#endif
}

