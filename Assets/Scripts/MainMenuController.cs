using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void ShowUseCase1()
    {
        SceneManager.LoadScene("Usecase01", LoadSceneMode.Single);
    }

    public void ShowUseCase2()
    {
        SceneManager.LoadScene("Usecase02", LoadSceneMode.Single);
    }

}
