using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class VoiceManager : MonoBehaviour {

    private string bingTokenUrl = "https://api.cognitive.microsoft.com/sts/v1.0/issueToken"; //トークン取得用URL
    private string apiKey = "b2a4aad438524c979b19b1f36c39d732";
    private string bingAPIUrl = "https://speech.platform.bing.com/speech/recognition/interactive/cognitiveservices/v1?language=ja-JP ";             //API呼び出し用URL

    public GameObject no2Panel_01;
    public GameObject no2Panel_02;
    public GameObject no2Panel_03;
    public GameObject no2Panel_04;
    public GameObject no2Panel_05;
    public GameObject no2Panel_06;
    public GameObject no2Panel_07;
    public GameObject no2Panel_08;
    public GameObject no2Panel_09;
    public GameObject no2Panel_10;

    private GameObject no2Panel_Current;
    private GameObject no3Panel_Current;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Microphone.IsRecording(null)) return;
        StartCoroutine(RecognizeVoice());
    }

    public void VoiceControl()
    {
        
    }

    IEnumerator RecognizeVoice()
    {
        AudioSource audio = GetComponentInChildren<AudioSource>();
        audio.clip = Microphone.Start(null, false, 2, 16000);
        //audio.loop = true;
        //while (!(Microphone.GetPosition(null) > 0)) { }
        //Debug.Log("start playing... position is " + Microphone.GetPosition(null));

        //textM.text = "start playing... position is " + Microphone.GetPosition(null);

        yield return new WaitForSeconds(2);
        //audio.Play();

        AudioClip clip = audio.clip;
        string audioFile = AudioSave.Save("HoloUC_WavJp", clip);

        //textM.text = audioFile;

        //textM.text = "start getting token...";

        //yield return new WaitForSeconds(1);

        var bingHeaders = new Dictionary<string, string>() {
            { "Ocp-Apim-Subscription-Key", apiKey }
        };
        //Tokenの取得
        //POSTで投げたいのでダミーとして空のバイト配列を入れている
        WWW www = new WWW(bingTokenUrl, new byte[1], bingHeaders); 
        yield return www;
        string bingToken = www.text;

        //textM.text = www.text;

        //SpeechAPIの呼び出し
        var headers = new Dictionary<string, string>() {
            { "Accept", @"application/json;text/xml"},
            { "Method", "POST"},
            { "Host", @"speech.platform.bing.com"},
            { "Content-Type", @"audio/wav; codec=""audio/pcm""; samplerate=16000"},
            { "Authorization", "Bearer "+ bingToken}
        };

        byte[] buffer = null;

        using (FileStream fs = new FileStream(audioFile, FileMode.Open, FileAccess.Read))
        {
            buffer = new Byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
        }

        WWW wwwAPI = new WWW(bingAPIUrl, buffer, headers);

        yield return wwwAPI;
        //textM.text = wwwAPI.text;

        var myResponse = JsonUtility.FromJson<MySpeechResponse>(wwwAPI.text);

        DoSthByVoice(myResponse.DisplayText);
        
    }

    private void DoSthByVoice(string voiceText)
    {
        if (String.IsNullOrEmpty(voiceText)) return;

        var debugText = GameObject.FindGameObjectWithTag("DebugText");
        var textM = debugText.GetComponent<TextMesh>();
        textM.text = voiceText;

        GameObject panel2 = null;
        GameObject panel3 = null;

        switch (voiceText)
        {
            case "日経":
                panel2 = no2Panel_01;
                break;
            case "トピックス":
                panel2 = no2Panel_02;
                break;
            case "ナスダック":
                panel2 = no2Panel_04;
                break;
        }

        if (panel2 == null ) return;

        Vector3 position = new Vector3();
        position.x = panel2.transform.position.x;
        position.y = panel2.transform.position.y;
        position.z = panel2.transform.position.z - 1.0f;

        panel2.transform.position = position;

        no2Panel_Current = panel2;
    }

    private void ToogleControlPanels(GameObject no2Panel, GameObject no3Panel)
    {
        if (no2Panel == null || no3Panel == null)
        {
            return;
        }

        if (no2Panel_Current == null || no3Panel_Current == null)
        {
            no2Panel_Current = no2Panel;
            no3Panel_Current = no3Panel;
        }
        else
        {
            if (no2Panel_Current.name == no2Panel.name)
            {
                return;
            }

            ToogleCurrentPanelPosition(no2Panel_Current, false);
            ToogleCurrentPanelPosition(no3Panel_Current, false);
        }

        no2Panel_Current = no2Panel;
        no3Panel_Current = no3Panel;
        ToogleCurrentPanelPosition(no2Panel_Current, true);
        ToogleCurrentPanelPosition(no3Panel_Current, true);
    }

    private void ToogleCurrentPanelPosition(GameObject panel, bool active)
    {
        Vector3 position = new Vector3();
        position.x = panel.transform.position.x;
        position.y = panel.transform.position.y;
        if (active)
        {
            position.z = panel.transform.position.z - 1.0f;
        }
        else
        {
            position.z = panel.transform.position.z + 1.0f;
        }

        panel.transform.position = position;
    }
}

