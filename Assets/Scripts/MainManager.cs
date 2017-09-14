using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

    public GameObject no2Panel;

    public GameObject no3Panel;

    private enum SubPanelPosition
    {
        Top,
        Left,
        Right,
        Bottom
    }

    // Use this for initialization
    void Start () {
        //no2Panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Nikke button clicked
    /// </summary>
    public void NikkeClick()
    {
        //var debugText = GameObject.Find("DebugText").GetComponent<TextMesh>();
        //debugText.text = "Nikke Clicked!";

        // Set value of labels in No.2 panel
        SetNo2PanelText("日経平均", "19741.42", "+195.61(1.82%)", true, "19545.81", "09/11", 
            "19631.67", "09:00", "19741.32", "14:10", "19615.12", "09:20", "904,136.700", 
            "09/12", "20142.76", "03/10", "19352.16", "07/26", SubPanelPosition.Top);
        // Set value of labels in No.3 panel
        SetNo3PanelText("日経平均", "19741.42", "+195.61(1.82%)", true, SubPanelPosition.Top);

        //Animator anim = no2Panel.GetComponent<Animator>();
        //anim.enabled = true;
        ////play the Slidein animation
        //anim.Play("No2PanelSlideIn");
    }

    /// <summary>
    /// Nikke button clicked
    /// </summary>
    public void TopixClick()
    {
        // Set value of labels in No.2 panel
        SetNo2PanelText("TOPIX", "1544.75", "+15.23(0.75%)", true, "1529.75", "09/11",
            "1544.67", "09:00", "1548.75", "14:00", "1531.15", "09:50", "74,219.900",
            "09/12", "1684.05", "03/10", "1494.25", "07/28", SubPanelPosition.Top);

        SetNo3PanelText("TOPIX", "1544.75", "+15.23(0.75%)", true, SubPanelPosition.Top);

    }

    /// <summary>
    /// FTSE button clicked
    /// </summary>
    public void FTSEClick()
    {
        // Set value of labels in No.2 panel
        SetNo2PanelText("英FTSE100", "10125.45", "+62.5(0.26%)", true, "10161.5", "09/11",
            "10125.45", "09:00", "10125.5", "09:30", "10125.5", "14:19", "181,254.273",
            "09/12", "10425.05", "03/10", "9825.45", "07/28", SubPanelPosition.Left);

        SetNo3PanelText("英FTSE100", "10125.45", "+62.5(0.26%)", true, SubPanelPosition.Left);
    }

    /// <summary>
    /// Nasdaq button clicked
    /// </summary>
    public void NasdaqClick()
    {
        // Set value of labels in No.2 panel
        SetNo2PanelText("ナスダック", "5725.81", "+21.5(0.49%)", true, "5691.5", "09/11",
            "5698.5", "09:00", "5756.5", "09:30", "5698.5", "13:22", "1,301,209.875",
            "09/12", "7198.05", "03/10", "4980.45", "07/28", SubPanelPosition.Right);

        SetNo3PanelText("ナスダック", "5725.81", "+21.5(0.49%)", true, SubPanelPosition.Right);
    }

    /// <summary>
    /// ShangHai button clicked
    /// </summary>
    public void ShangHaiClick()
    {
        // Set value of labels in No.2 panel
        SetNo2PanelText("上海総合", "3286.5", "-32.5(0.39%)", false, "3292.5", "09/11",
            "3296.5", "09:00", "3296.5", "09:00", "3256.25", "11:50", "1,904,219.900",
            "09/12", "5496.05", "03/08", "2245.45", "08/28", SubPanelPosition.Bottom);

        SetNo3PanelText("上海総合", "3286.5", "-32.5(0.39%)", false, SubPanelPosition.Bottom);
    }

    /// <summary>
    /// Set value of labels in No.2 Panel
    /// </summary>
    /// <param name="title"></param>
    /// <param name="index"></param>
    /// <param name="updown"></param>
    /// <param name="isUp"></param>
    /// <param name="yesterdayValue"></param>
    /// <param name="yesterdayDate"></param>
    /// <param name="startValue"></param>
    /// <param name="startValueTime"></param>
    /// <param name="highValue"></param>
    /// <param name="highValueTime"></param>
    /// <param name="lowValue"></param>
    /// <param name="lowValueTime"></param>
    /// <param name="turnoverValue"></param>
    /// <param name="turnoverDate"></param>
    /// <param name="thisYearHighValue"></param>
    /// <param name="thisYearHighDate"></param>
    /// <param name="thisYearLowValue"></param>
    /// <param name="thisYearLowDate"></param>
    private void SetNo2PanelText(
        string title, string index, string updown, bool isUp, string yesterdayValue, string yesterdayDate,
        string startValue, string startValueTime, string highValue, string highValueTime, string lowValue, 
        string lowValueTime, string turnoverValue, string turnoverDate, string thisYearHighValue,
        string thisYearHighDate, string thisYearLowValue, string thisYearLowDate, SubPanelPosition panelPostion)
    {
        var labels = no2Panel.GetComponentsInChildren<TextMesh>();
        foreach (var label in labels)
        {
            switch (label.name)
            {
                case "TitleLabel":
                    label.text = title + "株価";
                    break;
                case "IndexLabel":
                    label.text = index;
                    break;
                case "UpdownLabel":
                    label.text = updown;
                    label.color = isUp ? ConvertColor(255, 73, 6) : ConvertColor(20, 146, 255);
                    break;
                case "YesterdayValueLabel":
                    label.text = yesterdayValue;
                    break;
                case "YesterdayValueLabel2":
                    label.text = string.Format("({0})", yesterdayDate);
                    break;
                case "StartValueLabel":
                    label.text = startValue;
                    break;
                case "StartValueLabel2":
                    label.text = string.Format("({0})", startValueTime);
                    break;
                case "HighValueLabel":
                    label.text = highValue;
                    break;
                case "HighValueLabel2":
                    label.text = string.Format("({0})", highValueTime);
                    break;
                case "LowValueLabel":
                    label.text = lowValue;
                    break;
                case "LowValueLabel2":
                    label.text = string.Format("({0})", lowValueTime);
                    break;
                case "TurnoverValueLabel":
                    label.text = turnoverValue;
                    break;
                case "TurnoverValueLabel2":
                    label.text = string.Format("({0})", turnoverDate);
                    break;
                case "ThisYearHighValueLabel":
                    label.text = thisYearHighValue;
                    break;
                case "ThisYearHighValueLabel2":
                    label.text = string.Format("({0})", thisYearHighDate);
                    break;
                case "ThisYearLowValueLabel":
                    label.text = thisYearLowValue;
                    break;
                case "ThisYearLowValueLabel2":
                    label.text = string.Format("({0})", thisYearLowDate);
                    break;
            }
        }

        Vector3 position = new Vector3();
        switch (panelPostion)
        {
            case SubPanelPosition.Top:
                position.x = 0.18f;
                position.y = 0.27f;
                position.z = 2f;
                break;
            case SubPanelPosition.Left:
                position.x = -0.81f;
                position.y = 0.0f;
                position.z = 2f;
                break;
            case SubPanelPosition.Right:
                position.x = 0.81f;
                position.y = 0.0f;
                position.z = 2f;
                break;
            case SubPanelPosition.Bottom:
                position.x = 0.18f;
                position.y = -0.27f;
                position.z = 2f;
                break;
        }

        no2Panel.transform.position = position;

        no2Panel.SetActive(true);
    }

    /// <summary>
    /// Set value of labels in No.3 Panel
    /// </summary>
    private void SetNo3PanelText(string title, string index, string updown, bool isUp, SubPanelPosition panelPostion)
    {
        var labels = no3Panel.GetComponentsInChildren<TextMesh>();
        foreach (var label in labels)
        {
            switch (label.name)
            {
                case "TitleLabel":
                    label.text = title + "株価";
                    break;
                case "IndexLabel":
                    label.text = index;
                    break;
                case "UpdownLabel":
                    label.text = updown;
                    label.color = isUp ? ConvertColor(255, 73, 6) : ConvertColor(20, 146, 255);
                    break;
            }
        }

        Vector3 position = new Vector3();
        switch (panelPostion)
        {
            case SubPanelPosition.Top:
                position.x = -0.08f;
                position.y = 0.27f;
                position.z = 2f;
                break;
            case SubPanelPosition.Left:
                position.x = -0.545f;
                position.y = 0.0f;
                position.z = 2f;
                break;
            case SubPanelPosition.Right:
                position.x = 0.545f;
                position.y = 0.0f;
                position.z = 2f;
                break;
            case SubPanelPosition.Bottom:
                position.x = -0.08f;
                position.y = -0.27f;
                position.z = 2f;
                break;
        }

        no3Panel.transform.position = position;

        no3Panel.SetActive(true);
    }

    private Color ConvertColor(float r, float g, float b)
    {
        return new Color(r / 255, g / 255, b / 255);
    }
}
