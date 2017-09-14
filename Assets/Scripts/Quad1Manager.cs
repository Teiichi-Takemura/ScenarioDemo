using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Quad1Manager : MonoBehaviour, IInputClickHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Click event handler
    /// </summary>
    /// <param name="eventData"></param>
    public void OnInputClicked(InputClickedEventData eventData)
    {
        var debugText = GameObject.Find("DebugText").GetComponent<TextMesh>();

        var cam = Camera.main.transform;
        var headPosition = cam.position;
        var gazeDirection = cam.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            if (hitInfo.point.x > -0.47f && hitInfo.point.x < -0.32f &&
                hitInfo.point.y > 0.04f && hitInfo.point.y < 0.12f)
            {
                debugText.text = "Button 1 clicked!";
            }
            else
            {
                debugText.text = "";
            }

            //var camRel = cam.InverseTransformPoint(hitInfo.point);

            //debugText.text = string.Format("{0}, {1}, {2}\n{3}, {4}, {5}",
            //    hitInfo.point.x, hitInfo.point.y, hitInfo.point.z,
            //    transform.position.x, transform.position.y, transform.position.z);
            //    //camRel.x, camRel.y, camRel.z);
        }

        


    }
}
