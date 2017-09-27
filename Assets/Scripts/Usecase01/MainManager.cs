using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

    public GameObject no2Panel_01;
    public GameObject no3Panel_01;
    public GameObject no2Panel_02;
    public GameObject no3Panel_02;
    public GameObject no2Panel_03;
    public GameObject no3Panel_03;
    public GameObject no2Panel_04;
    public GameObject no3Panel_04;
    public GameObject no2Panel_05;
    public GameObject no3Panel_05;
    public GameObject no2Panel_06;
    public GameObject no3Panel_06;
    public GameObject no2Panel_07;
    public GameObject no3Panel_07;
    public GameObject no2Panel_08;
    public GameObject no3Panel_08;
    public GameObject no2Panel_09;
    public GameObject no3Panel_09;
    public GameObject no2Panel_10;
    public GameObject no3Panel_10;

    //private enum SubPanelPosition
    //{
    //    Top,
    //    Left,
    //    Right,
    //    Bottom
    //}

    // Use this for initialization
    void Start () {
        // Nikke
        ShowNikke();
        // Topix
        ShowTopix();
        // NYDow
        ShowNYDow();
        // Nasdaq
        ShowNasdaq();

        // IBOV
        SetNo2PanelText(no2Panel_05, "ブラジルボベスパ", "55,480.87", "+950.98.5(1.63%)", true);
        SetNo3PanelText(no3Panel_05, "ブラジルボベスパ", "55,480.87", "+950.98.5(1.63%)", true, "54,630.27", "09/11",
            "54,630.27", "09:00", "54,930.27", "09:10", "54,130.27", "14:02", "2,101,175.209",
            "09/12", "59,630.27", "02/13", "51,630.27", "08/21");

        // ShangHai
        SetNo2PanelText(no2Panel_06, "上海総合", "3286.5", "-32.5(0.39%)", false);
        SetNo3PanelText(no3Panel_06, "上海総合", "3286.5", "-32.5(0.39%)", false, "3292.5", "09/11",
            "3296.5", "09:00", "3296.5", "09:00", "3256.25", "11:50", "1,904,219.900",
            "09/12", "5496.05", "03/08", "2245.45", "08/28");

        // HKH
        SetNo2PanelText(no2Panel_07, "香港ハンセン", "22908.65", "+105.8(0.54%)", true);
        SetNo3PanelText(no3Panel_07, "香港ハンセン", "22908.65", "+105.8(0.54%)", true, "22783.45", "09/11",
            "22783.45", "09:00", "22983.45", "09:05", "22703.45", "13:50", "204,385.418",
            "09/12", "25183.45", "01/09", "20180.15", "06/11");

        // CAC
        SetNo2PanelText(no2Panel_08, "仏CAC40", "4553.25", "-21.5(0.16%)", false);
        SetNo3PanelText(no3Panel_08, "仏CAC40", "4553.25", "-21.5(0.16%)", false, "4574.75", "09/11",
            "4573.15", "09:00", "4613.65", "13:08", "4520.15", "10:10", "1,090,012.095",
            "09/12", "4850.15", "04/08", "4250.95", "08/01");

        // FTSE
        SetNo2PanelText(no2Panel_09, "英FTSE100", "6654.47", "+26.18(0.39%)", true);
        SetNo3PanelText(no3Panel_09, "英FTSE100", "6654.47", "+26.18(0.39%)", true, "6628.29", "09/11",
            "6621.29", "09:00", "6698.30", "14:10", "6598.18", "09:19", "870,284.097",
            "09/12", "7128.35", "02/25", "6308.08", "07/08");

        // DAX
        SetNo2PanelText(no2Panel_10, "独DAX30指数", "10125.45", "-101.5(0.46%)", false);
        SetNo3PanelText(no3Panel_10, "独DAX30指数", "10125.45", "-101.5(0.46%)", false, "10161.5", "09/11",
            "10125.45", "09:00", "10125.5", "09:30", "10125.5", "14:19", "181,254.273",
            "09/12", "10425.05", "03/10", "9825.45", "07/28");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Nikke button clicked
    /// </summary>
    public void ShowNikke()
    {
        //var debugText = GameObject.Find("DebugText").GetComponent<TextMesh>();
        //debugText.text = "Nikke Clicked!";

        SetNo2PanelText(no2Panel_01, "日経平均", "19741.42", "+195.61(1.82%)", true);
        SetNo3PanelText(no3Panel_01, "日経平均", "19741.42", "+195.61(1.82%)", true, "19545.81", "09/11",
            "19631.67", "09:00", "19741.32", "14:10", "19615.12", "09:20", "904,136.700", "09/12",
            "20142.76", "03/10", "19352.16", "07/26");

        no2Panel_01.SetActive(true);
        no3Panel_01.SetActive(true);
    }

    /// <summary>
    /// Nikke button clicked
    /// </summary>
    public void ShowTopix()
    {
        SetNo2PanelText(no2Panel_02, "TOPIX", "1544.75", "+15.23(0.75%)", true);
        SetNo3PanelText(no3Panel_02, "TOPIX", "1544.75", "+15.23(0.75%)", true, "1529.75", "09/11",
            "1544.67", "09:00", "1548.75", "14:00", "1531.15", "09:50", "74,219.900",
            "09/12", "1684.05", "03/10", "1494.25", "07/28");

        no2Panel_02.SetActive(true);
        no3Panel_02.SetActive(true);
    }

    /// <summary>
    /// NYDow button clicked
    /// </summary>
    public void ShowNYDow()
    {
        SetNo2PanelText(no2Panel_03, "NYダウ", "18506.49", "+16.5(0.069%)", true);
        SetNo3PanelText(no3Panel_03, "NYダウ", "18506.49", "+16.5(0.069%)", true, "18495.5", "09/11",
            "18495.5", "09:00", "18567.5", "11:15", "18235.5", "13:24", "391,434.098",
            "09/12", "19875.5", "03/21", "17128.5", "07/23");

        no2Panel_03.SetActive(true);
        no3Panel_03.SetActive(true);
    }

    /// <summary>
    /// Nasdaq button clicked
    /// </summary>
    public void ShowNasdaq()
    {
        SetNo2PanelText(no2Panel_04, "ナスダック", "5725.81", "+21.5(0.49%)", true);
        SetNo3PanelText(no3Panel_04, "ナスダック", "5725.81", "+21.5(0.49%)", true, "5691.5", "09/11",
            "5698.5", "09:00", "5756.5", "09:30", "5698.5", "13:22", "1,301,209.875",
            "09/12", "7198.05", "03/10", "4980.45", "07/28");

        no2Panel_04.SetActive(true);
        no3Panel_04.SetActive(true);
    }

    /// <summary>
    /// FTSE button clicked
    /// </summary>
    public void FTSEClick()
    {
        //// Set value of labels in No.2 panel
        //SetNo2PanelText("英FTSE100", "10125.45", "+62.5(0.26%)", true, "10161.5", "09/11",
        //    "10125.45", "09:00", "10125.5", "09:30", "10125.5", "14:19", "181,254.273",
        //    "09/12", "10425.05", "03/10", "9825.45", "07/28", SubPanelPosition.Left);

        //SetNo3PanelText("英FTSE100", "10125.45", "+62.5(0.26%)", true, SubPanelPosition.Left);
    }

    /// <summary>
    /// Nasdaq button clicked
    /// </summary>
    public void NasdaqClick()
    {
        // Set value of labels in No.2 panel
        //SetNo2PanelText("ナスダック", "5725.81", "+21.5(0.49%)", true, "5691.5", "09/11",
        //    "5698.5", "09:00", "5756.5", "09:30", "5698.5", "13:22", "1,301,209.875",
        //    "09/12", "7198.05", "03/10", "4980.45", "07/28", SubPanelPosition.Right);

        //SetNo3PanelText("ナスダック", "5725.81", "+21.5(0.49%)", true, SubPanelPosition.Right);
    }

    /// <summary>
    /// ShangHai button clicked
    /// </summary>
    public void ShangHaiClick()
    {
        // Set value of labels in No.2 panel
        //SetNo2PanelText("上海総合", "3286.5", "-32.5(0.39%)", false, "3292.5", "09/11",
        //    "3296.5", "09:00", "3296.5", "09:00", "3256.25", "11:50", "1,904,219.900",
        //    "09/12", "5496.05", "03/08", "2245.45", "08/28", SubPanelPosition.Bottom);

        //SetNo3PanelText("上海総合", "3286.5", "-32.5(0.39%)", false, SubPanelPosition.Bottom);
    }

    /// <summary>
    /// Set value of labels in No.2 Panel
    /// </summary>
    /// <param name="panel"></param>
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
    private void SetNo3PanelText(GameObject panel,
        string title, string index, string updown, bool isUp, string yesterdayValue, string yesterdayDate,
        string startValue, string startValueTime, string highValue, string highValueTime, string lowValue, 
        string lowValueTime, string turnoverValue, string turnoverDate, string thisYearHighValue,
        string thisYearHighDate, string thisYearLowValue, string thisYearLowDate)
    {
        if (panel == null) return;
        var labels = panel.GetComponentsInChildren<TextMesh>();
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

        //Vector3 position = new Vector3();
        //switch (panelPostion)
        //{
        //    case SubPanelPosition.Top:
        //        position.x = 0.18f;
        //        position.y = 0.27f;
        //        position.z = 2f;
        //        break;
        //    case SubPanelPosition.Left:
        //        position.x = -0.81f;
        //        position.y = 0.0f;
        //        position.z = 2f;
        //        break;
        //    case SubPanelPosition.Right:
        //        position.x = 0.81f;
        //        position.y = 0.0f;
        //        position.z = 2f;
        //        break;
        //    case SubPanelPosition.Bottom:
        //        position.x = 0.18f;
        //        position.y = -0.27f;
        //        position.z = 2f;
        //        break;
        //}

        //no2Panel.transform.position = position;

        //no2Panel.SetActive(true);
    }

    /// <summary>
    /// Set value of labels in No.3 Panel
    /// </summary>
    private void SetNo2PanelText(GameObject panel, string title, string index, string updown, bool isUp)
    {
        if (panel == null) return;
        var labels = panel.GetComponentsInChildren<TextMesh>();
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

        //Vector3 position = new Vector3();
        //switch (panelPostion)
        //{
        //    case SubPanelPosition.Top:
        //        position.x = -0.08f;
        //        position.y = 0.27f;
        //        position.z = 2f;
        //        break;
        //    case SubPanelPosition.Left:
        //        position.x = -0.545f;
        //        position.y = 0.0f;
        //        position.z = 2f;
        //        break;
        //    case SubPanelPosition.Right:
        //        position.x = 0.545f;
        //        position.y = 0.0f;
        //        position.z = 2f;
        //        break;
        //    case SubPanelPosition.Bottom:
        //        position.x = -0.08f;
        //        position.y = -0.27f;
        //        position.z = 2f;
        //        break;
        //}

        //no3Panel.transform.position = position;

        //no3Panel.SetActive(true);
    }

    private Color ConvertColor(float r, float g, float b)
    {
        return new Color(r / 255, g / 255, b / 255);
    }
}
