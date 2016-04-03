using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    private GameObject inventoryPanel;
    private GameObject slotPanel;
    private int slotAmount;
    private ItemDatabase database;
    
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    public GameObject mainCamera;
    public GameObject invenCamera;
    public GameObject shopPanel;
    public GameObject invenPanel;
    public GameObject invTooltipPanel;

	// Use this for initialization
	void Start () 
    {
        

        database = GetComponent<ItemDatabase>();

        slotAmount = 50;
        inventoryPanel = GameObject.Find("InventoryPanel");
        slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;

        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);

        }

        mainCamera.SetActive(true);
        invenCamera.SetActive(false);
       

        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1); 
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);

        AddItem(1);
        AddItem(0);
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        if(itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for(int i = 0; i< items.Count; i++)
            {
                if(items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                    
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.position = Vector2.zero;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.name = itemToAdd.Title;
                    break;
                }
            }
        }
    }


    public void ChangeCamera(int nNumber)
    {
        if(nNumber == 1) //main on
        {
            mainCamera.SetActive(true);
            invenCamera.SetActive(false);
            
            shopPanel.SetActive(false);
        }
        else if(nNumber == 2) //inven on
        {
            mainCamera.SetActive(false);
            invenCamera.SetActive(true);
            invenPanel.SetActive(true);
            shopPanel.SetActive(false);
        }
        else if(nNumber == 3) // shop on
        {
            mainCamera.SetActive(false);
            invenCamera.SetActive(true);
            invenPanel.SetActive(false);
            shopPanel.SetActive(true);
        }

    }

    bool CheckIfItemIsInInventory(Item item)
    {
        for(int i =0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return true;
        }
        return false;
    }

}
