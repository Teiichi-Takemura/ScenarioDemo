using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPanel : MonoBehaviour {

    public GameObject panel;

	// Use this for initialization
	void Start () {
		
	}

    public void ToggleControlPanelView()
    {
        if (panel == null) return;

        panel.SetActive(!panel.activeSelf);
    }

    
}
