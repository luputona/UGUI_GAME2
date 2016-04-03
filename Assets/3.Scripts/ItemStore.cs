using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemStore : MonoBehaviour {

    private GameObject ListPanel;
    private GameObject GridWith;
    private GameObject slotPanel;


    private int slotAmount;
    private ItemDatabase database;

    public GameObject storeSlot;
    public GameObject storeItem;

    public int id;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    public StoreSlot itemList;

    
	// Use this for initialization
	void Start () 
    {
        database = GetComponent<ItemDatabase>();

        SellList(1);
        SellList(0);
        SellList(1);

        //list();
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void list()
    {        
        if(itemList.id == 0)
        {
            storeItem.GetComponent<Image>().sprite = database.FetchItemByID(0).Sprite;
            storeItem.name = database.FetchItemByID(0).Title;
        }
    }

    public void SellList(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);

        for (int i = 0; i < items.Count; i++ )
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                
                storeItem.GetComponent<Image>().sprite = itemToAdd.Sprite;
                storeItem.name = itemToAdd.Title;
                
            }
        }
            

    }

    bool CheckIfItemIsInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return true;
        }
        return false;
    }
}
