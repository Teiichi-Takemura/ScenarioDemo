using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Examples.InteractiveElements;

public class No1PanelController : MonoBehaviour
{
    public GameObject StockItemPrefab;

    public GameObject No2Panel;

    public GameObject No3Panel;

    public GameObject No4Panel;

    public GameObject No5Panel;

    // Use this for initialization
    void Start()
    {
        CreateStockItem(1, "6397", "東証２部", "(株)郷鉄工所", "14:06", "32", true, "33.33", "8", "19,157,000", "鉄鋼");
        CreateStockItem(2, "4274", "東証JQS", "細谷火工(株)", "12:41", "1,395", true, "27.40", "300", "852,000", "その他製品");
        CreateStockItem(3, "1689", "東証ETF", "ETFS　天然ガス上場投資信託", "14:06", "5", true, "25.00", "1", "351,800", "電気・ガス業");
        CreateStockItem(4, "4976", "東証JQS", "東洋ドライルーブ(株)", "14:41", "2,569", false, "12.11", "254", "25,300", "ゴム製品");
        CreateStockItem(5, "3758", "東証JQS", "(株)フエリア", "14:01", "2,593", true, "23.89", "500", "4,245,200", "化学");
        CreateStockItem(6, "6208", "東証１部", "(株)石川製作所", "13:41", "1,725", true, "21.05", "300", "3,151,800", "その他製品");
        CreateStockItem(7, "3150", "東証JQS", "(株)グリムス", "14:07", "1,679", true, "19.67", "276", "89,100", "電気・ガス業");
        CreateStockItem(8, "6149", "東証JQS", "(株)小田原エンジニアリング", "14:06", "1,962", false, "19.49", "320", "544,100", "精密機器");
        CreateStockItem(9, "7743", "東証１部", "(株)シード", "14:07", "2,760", true, "18.25", "426", "100,000", "建設業");
        CreateStockItem(10, "6092", "マザーズ", "(株)エンバイオ・ホールディングス", "14:07", "1,260", true, "17.54", "188", "1,391,500", "サービス");
        CreateStockItem(11, "6397", "東証２部", "(株)郷鉄工所", "14:06", "32", true, "33.33", "8", "19,157,000", "鉄鋼");
        CreateStockItem(12, "4274", "東証JQS", "細谷火工(株)", "12:41", "1,395", true, "27.40", "300", "852,000", "その他製品");
        CreateStockItem(13, "1689", "東証ETF", "ETFS　天然ガス上場投資信託", "14:06", "5", true, "25.00", "1", "351,800", "電気・ガス業");
        CreateStockItem(14, "4976", "東証JQS", "東洋ドライルーブ(株)", "14:41", "2,569", false, "12.11", "254", "25,300", "ゴム製品");
        CreateStockItem(15, "3758", "東証JQS", "(株)フエリア", "14:01", "2,593", true, "23.89", "500", "4,245,200", "化学");
        CreateStockItem(16, "6208", "東証１部", "(株)石川製作所", "13:41", "1,725", true, "21.05", "300", "3,151,800", "その他製品");
        CreateStockItem(17, "3150", "東証JQS", "(株)グリムス", "14:07", "1,679", true, "19.67", "276", "89,100", "電気・ガス業");
        CreateStockItem(18, "6149", "東証JQS", "(株)小田原エンジニアリング", "14:06", "1,962", false, "19.49", "320", "544,100", "精密機器");
        CreateStockItem(19, "7743", "東証１部", "(株)シード", "14:07", "2,760", true, "18.25", "426", "100,000", "建設業");
        CreateStockItem(20, "6092", "マザーズ", "(株)エンバイオ・ホールディングス", "14:07", "1,260", true, "17.54", "188", "1,391,500", "サービス");

        //var stockItem = Instantiate(StockItemPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        //stockItem.transform.parent = gameObject.transform;
        ////stockItem.transform.localPosition = Vector3.zero;
        //stockItem.transform.localScale = new Vector3(2.655f, 0.5f, 1.0f);
        ////stockItem.transform.position = new Vector3(-0.0023f, 0.401f, -0.008f); ;
        //    stockItem.transform.position = new Vector3(gameObject.transform.position.x -0.0016f, 
        //        gameObject.transform.position.y + 0.20025f, gameObject.transform.position.z - 0.008f);

        //var stockItem2 = Instantiate(StockItemPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        //stockItem2.transform.parent = gameObject.transform;
        ////stockItem.transform.localPosition = Vector3.zero;
        //stockItem2.transform.localScale = new Vector3(2.655f, 0.5f, 1.0f);
        ////stockItem.transform.position = new Vector3(-0.0023f, 0.401f, -0.008f); ;
        //stockItem2.transform.position = new Vector3(gameObject.transform.position.x - 0.0016f,
        //    gameObject.transform.position.y + 0.18000f, gameObject.transform.position.z - 0.008f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateStockItem(
        int itemNo, string stockCode, string stockMarket, string stockName, string dealTime, string dealValue, 
        bool isPlusToYesterday, string ratioToYesterday, string valueToYesterday, string dealAmount, string stockIndustry)
    {
        // create stock item and put it to the right position of the no.1 panel
        var parentTransform = gameObject.transform;
        var stockItem = Instantiate(StockItemPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        stockItem.transform.parent = parentTransform;
        stockItem.transform.localScale = new Vector3(2.655f, 0.5f, 1.0f);

        stockItem.transform.position = new Vector3(parentTransform.position.x - 0.0016f,
            parentTransform.position.y + 0.22050f - 0.01900f * itemNo, parentTransform.position.z - 0.008f);
        
        // append select event
        var interactiveModel = stockItem.GetComponent<Interactive>();
        if (interactiveModel != null)
        {
            interactiveModel.OnSelectEvents.AddListener(() => {

                SelectStock(stockCode, dealValue, stockName, isPlusToYesterday, ratioToYesterday, valueToYesterday, stockIndustry);

            });
        }

        // set value of labels
        var labels = stockItem.GetComponentsInChildren<TextMesh>();
        foreach (var label in labels)
        {
            switch (label.name)
            {
                case "Label01":
                    // No
                    label.text = itemNo.ToString();
                    break;
                case "Label02":
                    // 銘柄コード
                    label.text = stockCode;
                    break;
                case "Label03":
                    // 市場
                    label.text = stockMarket;
                    break;
                case "Label04":
                    // 銘柄名称
                    label.text = stockName;
                    break;
                case "Label05":
                    // 取引時間
                    label.text = dealTime;
                    break;
                case "Label06":
                    // 取引値
                    label.text = dealValue;
                    break;
                case "Label07":
                    // 前日比
                    if (isPlusToYesterday)
                    {
                        label.text = "+" + ratioToYesterday;
                        label.color = ConvertColor(84, 150, 84);
                    }
                    else
                    {
                        label.text = "-" + ratioToYesterday;
                        label.color = ConvertColor(248, 78, 75);
                    }
                    break;
                case "Label08":
                    // 前日比（値）
                    if (isPlusToYesterday)
                    {
                        label.text = "+" + valueToYesterday;
                        label.color = ConvertColor(84, 150, 84);
                    }
                    else
                    {
                        label.text = "-" + valueToYesterday;
                        label.color = ConvertColor(248, 78, 75);
                    }
                    break;
                case "Label09":
                    // 出来高
                    label.text = dealAmount;
                    break;
            }
        }
    }

    private Color ConvertColor(float r, float g, float b)
    {
        return new Color(r / 255, g / 255, b / 255);
    }

    public void SelectStock(string stockCode, string stockValue, string stockName, bool isPlusToYesterday,
        string ratioToYesterday, string valueToYesterday, string stockIndustry)
    {
        //var debugText = GameObject.Find("DebugText2").GetComponent<TextMesh>();
        //debugText.text = stockCode + " Clicked!";

        // Set value of labels in No.2 panel
        SetNo2PanelText(
            stockCode, stockValue, stockName, isPlusToYesterday, ratioToYesterday, valueToYesterday, stockIndustry);

        // Set value of labels in No.3 panel
        SetNo3PanelText(
            stockCode, stockValue, stockName, isPlusToYesterday, ratioToYesterday, valueToYesterday, stockIndustry);

        // Set value of labels in No.4 panel
        SetNo4PanelText(
            stockCode, stockValue, stockName, isPlusToYesterday, ratioToYesterday, valueToYesterday, stockIndustry);

        // Set value of labels in No.5 panel
        SetNo5PanelText(
            stockCode, stockValue, stockName, isPlusToYesterday, ratioToYesterday, valueToYesterday, stockIndustry);
    }

    private void SetNo2PanelText(string stockCode, string stockValue, string stockName, bool isPlusToYesterday,
        string ratioToYesterday, string valueToYesterday, string stockIndustry)
    {
        if (No2Panel == null) return;

        var labels = No2Panel.GetComponentsInChildren<TextMesh>();
        foreach (var label in labels)
        {
            switch (label.name)
            {
                case "StockCodeLabel":
                    label.text = stockCode;
                    break;
                case "StockTypeLabel":
                    label.text = stockIndustry;
                    break;
                case "StockNameLabel":
                    label.text = stockName;
                    break;
                case "StockValueLabel":
                    label.text = stockValue;
                    break;
                case "UpdownLabel":
                    var labelText = string.Format("{0}({1})", ratioToYesterday, valueToYesterday);

                    if (isPlusToYesterday)
                    {
                        label.text = "+" + labelText;
                        label.color = ConvertColor(255, 73, 6);
                    }
                    else
                    {
                        label.text = "-" + labelText;
                        label.color = ConvertColor(20, 146, 255);
                    }
                    break;
            }
        }

        // set stock chart
        var chart = No2Panel.GetComponentInChildren<SpriteRenderer>();
        var spriteName = createSpriteName(chart.sprite.ToString());
        chart.sprite  = Resources.Load<Sprite>(spriteName);
        
        No2Panel.SetActive(true);
    }

    private void SetNo3PanelText(string stockCode, string stockValue, string stockName, bool isPlusToYesterday,
        string ratioToYesterday, string valueToYesterday, string stockIndustry)
    {
        if (No3Panel == null) return;

        var labels = No3Panel.GetComponentsInChildren<TextMesh>();
        foreach (var label in labels)
        {
            switch (label.name)
            {
                case "StockCodeLabel":
                    label.text = stockCode;
                    break;
                case "StockTypeLabel":
                    label.text = stockIndustry;
                    break;
                case "StockNameLabel":
                    label.text = stockName;
                    break;
                case "StockValueLabel":
                    label.text = stockValue;
                    break;
                case "UpdownLabel":
                    var labelText = string.Format("{0}({1})", ratioToYesterday, valueToYesterday);

                    if (isPlusToYesterday)
                    {
                        label.text = "+" + labelText;
                        label.color = ConvertColor(255, 73, 6);
                    }
                    else
                    {
                        label.text = "-" + labelText;
                        label.color = ConvertColor(20, 146, 255);
                    }
                    break;
                case "YesterdayValueLabel":
                    label.text = (float.Parse(stockValue) - float.Parse(valueToYesterday)).ToString();
                    break;
                case "StartValueLabel":
                    label.text = (float.Parse(stockValue) - float.Parse(stockValue) * 0.05).ToString();
                    break;
                case "HighValueLabel":
                    label.text = (float.Parse(stockValue) + float.Parse(stockValue) * 0.05).ToString();
                    break;
                case "HighValueLabel2":
                    label.text = "(" + (Random.Range(10, 15)).ToString() + ":" + (Random.Range(10, 60)).ToString() + ")";
                    break;
                case "LowValueLabel":
                    label.text = (float.Parse(stockValue) - float.Parse(stockValue) * 0.1).ToString();
                    break;
                case "LowValueLabel2":
                    label.text = "(" + (Random.Range(10, 15)).ToString() + ":" + (Random.Range(10, 60)).ToString() + ")";
                    break;
                case "TurnoverValueLabel":
                    label.text = (Random.Range(100000, 100000000)).ToString("0,0");
                    break;
                case "ThisYearHighValueLabel":
                    label.text = (Random.Range(100000, 10000000)).ToString("0,0") + "千円";
                    break;
                case "ThisYearLowValueLabel":
                    label.text = (float.Parse(stockValue) * 0.9).ToString("0,0") + " ~ " + (float.Parse(stockValue) * 1.1).ToString("0,0");
                    break;
            }
        }

        No3Panel.SetActive(true);
    }

    private void SetNo4PanelText(string stockCode, string stockValue, string stockName, bool isPlusToYesterday,
        string ratioToYesterday, string valueToYesterday, string stockIndustry)
    {
        if (No4Panel == null) return;

        var labels = No4Panel.GetComponentsInChildren<TextMesh>();

        foreach (var label in labels)
        {
            switch (label.name)
            {
                case "StockCodeLabel":
                    label.text = stockCode;
                    break;
                case "StockTypeLabel":
                    label.text = stockIndustry;
                    break;
                case "StockNameLabel":
                    label.text = stockName;
                    break;
                case "StockValueLabel":
                    label.text = stockValue;
                    break;
                case "UpdownLabel":
                    var labelText = string.Format("{0}({1})", ratioToYesterday, valueToYesterday);

                    if (isPlusToYesterday)
                    {
                        label.text = "+" + labelText;
                        label.color = ConvertColor(255, 73, 6);
                    }
                    else
                    {
                        label.text = "-" + labelText;
                        label.color = ConvertColor(20, 146, 255);
                    }
                    break;
            }
        }

        // set stock chart
        //var chart = No4Panel.GetComponentInChildren<SpriteRenderer>();
        //var spriteName = createSpriteName(chart.sprite.ToString());
        //chart.sprite = Resources.Load<Sprite>(spriteName);

    }

    private void SetNo5PanelText(string stockCode, string stockValue, string stockName, bool isPlusToYesterday,
        string ratioToYesterday, string valueToYesterday, string stockIndustry)
    {
        if (No5Panel == null) return;

        var labels = No5Panel.GetComponentsInChildren<TextMesh>();

        foreach (var label in labels)
        {
            switch (label.name)
            {
                case "StockCodeLabel":
                    label.text = stockCode;
                    break;
                case "StockTypeLabel":
                    label.text = stockIndustry;
                    break;
                case "StockNameLabel":
                    label.text = stockName;
                    break;
                case "StockValueLabel":
                    label.text = stockValue;
                    break;
                case "UpdownLabel":
                    var labelText = string.Format("{0}({1})", ratioToYesterday, valueToYesterday);

                    if (isPlusToYesterday)
                    {
                        label.text = "+" + labelText;
                        label.color = ConvertColor(255, 73, 6);
                    }
                    else
                    {
                        label.text = "-" + labelText;
                        label.color = ConvertColor(20, 146, 255);
                    }
                    break;
            }
        }

        // set stock chart
        //var chart = No4Panel.GetComponentInChildren<SpriteRenderer>();
        //var spriteName = createSpriteName(chart.sprite.ToString());
        //chart.sprite = Resources.Load<Sprite>(spriteName);
    }

    private string createSpriteName(string currentOne)
    {
        var result = string.Format("usecase02-P02-0{0}", Random.Range(6, 10).ToString());

        if (currentOne.IndexOf(result) >= 0)
            return createSpriteName(currentOne);
        else
            return result;
    }
}
