using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;

public class UC2Manager : MonoBehaviour, ISpeechHandler
{
    private SpeechInputSource speechInput;  
    // Use this for initialization
    void Start () {
        //SetupSpeechInputSource();
        //// ManualStart の場合は、任意のタイミングで StartKeywordRecognizer を実行する。
        //speechInput.StartKeywordRecognizer();
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    private void SetupSpeechInputSource()
    {
        // 認識させたいキーワード一覧を作成する。
        var keywords = new List<SpeechInputSource.KeywordAndKeyCode>();
        var keywordVoiceInput = new SpeechInputSource.KeywordAndKeyCode();
        keywordVoiceInput.Keyword = "back";
        keywords.Add(keywordVoiceInput);

        // SpeechInputSource のコンポーネントを取得
        speechInput = gameObject.GetComponent<SpeechInputSource>();
        // キーワード一覧を設定する。
        speechInput.Keywords = keywords.ToArray();
        // 音声認識を開始する条件を設定。
        // 自動で開始させる場合は特に必要ないが、任意のタイミングで開始する場合は ManualStart を指定する。 
        speechInput.RecognizerStart = SpeechInputSource.RecognizerStartBehavior.ManualStart;
    }

    public void OnSpeechKeywordRecognized(SpeechKeywordRecognizedEventData eventData)
    {
        // 指定したキーワードを認識すると、このメソッドが呼ばれる。
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}
