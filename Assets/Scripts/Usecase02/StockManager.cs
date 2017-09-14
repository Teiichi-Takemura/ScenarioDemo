using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectStock()
    {
        var debugText = GameObject.Find("DebugText2").GetComponent<TextMesh>();
        debugText.text = "Stock selected!";
    }
}
