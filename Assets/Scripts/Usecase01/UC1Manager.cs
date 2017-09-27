using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UC1Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void GotoMainScene()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}
