using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No1PanelController : MonoBehaviour {

    public GameObject StockItemPrefab;

	// Use this for initialization
	void Start () {

        for (var i = 0; i < 10; i++)
        {
            CreateStockItem(i);
        }

        
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
	void Update () {
		
	}

    private void CreateStockItem(int itemNo)
    {
        var parentTransform = gameObject.transform;
        var stockItem = Instantiate(StockItemPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        stockItem.transform.parent = parentTransform;
        stockItem.transform.localScale = new Vector3(2.655f, 0.5f, 1.0f);

        stockItem.transform.position = new Vector3(parentTransform.position.x - 0.0016f,
            parentTransform.position.y + 0.20025f - 0.02025f * itemNo, parentTransform.position.z - 0.008f);
    }
}
