using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No2PanelController : MonoBehaviour {

    [Tooltip("No4Panel")]
    public GameObject No4Panel;

    [Tooltip("No5Panel")]
    public GameObject No5Panel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowNextPanel()
    {
        if (No4Panel == null) return;

        No4Panel.SetActive(true);

        if (No5Panel == null) return;

        No5Panel.SetActive(true);

#if UNITY_UWP && !UNITY_EDITOR
        if (SharingManager.Instance.IsExportEventEnabled)
        {  
            SharingManager.Instance.SendEvent(System.Text.Encoding.UTF8.GetBytes("ShowNextPanel"));
        }
#endif
    }

    //private void SetNo4PanelText()
    //{
    //    if (No4Panel == null) return;

    //    var labels = No4Panel.GetComponentsInChildren<TextMesh>();

    //    foreach (var label in labels)
    //    {
    //        switch (label.name)
    //        {
    //            case "StockCodeLabel":
    //                label.text = GetLabelValue(label.name);
    //                break;
    //            case "StockTypeLabel":
    //                label.text = GetLabelValue(label.name);
    //                break;
    //            case "StockNameLabel":
    //                label.text = GetLabelValue(label.name);
    //                break;
    //            case "StockValueLabel":
    //                label.text = GetLabelValue(label.name);
    //                break;
    //            case "UpdownLabel":
    //                label.text = GetLabelValue(label.name);

    //                if (label.text.Substring(0, 1) == "+")
    //                {
    //                    label.color = ConvertColor(255, 73, 6);
    //                }
    //                else
    //                {
    //                    label.color = ConvertColor(20, 146, 255);
    //                }
    //                break;
    //        }
    //    }

    //    // set stock chart
    //    //var chart = No4Panel.GetComponentInChildren<SpriteRenderer>();
    //    //var spriteName = createSpriteName(chart.sprite.ToString());
    //    //chart.sprite = Resources.Load<Sprite>(spriteName);

    //    No4Panel.SetActive(true);
    //}

    //private string GetLabelValue(string labelName)
    //{
    //    var sourceLabels = gameObject.GetComponentsInChildren<TextMesh>();

    //    foreach (var label in sourceLabels)
    //    {
    //        if (label.name == labelName)
    //        {
    //            return label.text;
    //        }
    //    }

    //    return string.Empty;
    //}

    private Color ConvertColor(float r, float g, float b)
    {
        return new Color(r / 255, g / 255, b / 255);
    }
}
