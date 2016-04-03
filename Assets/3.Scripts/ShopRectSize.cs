using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopRectSize : MonoBehaviour {

    private RectTransform rectTran;
   

	// Use this for initialization
	void Start () {
        rectTran = GetComponent<RectTransform>();
        rectTran.localScale = new Vector3(1, 1, 1);

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
