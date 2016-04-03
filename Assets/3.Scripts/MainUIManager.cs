using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MainUIManager : MonoBehaviour
{

    public GameObject mainUI;
    public GameObject selectMapUI;
    public GameObject explainPanel;
    public GameObject InvenCamera;

	// Use this for initialization
	void Start () 
    {
        mainUI.SetActive(true);
        selectMapUI.gameObject.SetActive(false);
        explainPanel.gameObject.SetActive(false);
        InvenCamera.gameObject.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Areaexplain(string _switch)
    {
        if(_switch == "On")
        {
            explainPanel.gameObject.SetActive(true);
        }
        else if(_switch == "Off")
        {
            explainPanel.gameObject.SetActive(false);
        }
    }

    public void ChangeMapUI(string _switch)
    {
        if(_switch == "Off")
        {
            selectMapUI.gameObject.SetActive(false);
            mainUI.gameObject.SetActive(true);
        }
        else if(_switch == "On")
        {
            selectMapUI.gameObject.SetActive(true);
            mainUI.gameObject.SetActive(false);
        }        
    }

    public void ChangeInforUI(string _switch)
    {
        if(_switch == "Off")
        {
            mainUI.gameObject.SetActive(false);
            
        }
        else if (_switch == "On")
        {
            mainUI.gameObject.SetActive(true);
            selectMapUI.gameObject.SetActive(false);

        }
    }

   
}
