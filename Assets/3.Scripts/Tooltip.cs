using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Tooltip : MonoBehaviour {

    private Item item;
    private string data;
    private GameObject tooltip;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);


    }
    void Update()
    {
        if(tooltip.activeSelf)
        {
           tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

	public void Deactivate()
    {
        tooltip.SetActive(false);

    }

    public void ConstructDataString()
    {
        if (item.Rarity == 1)
        {
            data = "<color=#ffffff><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n\nPower : " + item.Power + "\nDefence : " + item.Defence + "\nVitality : " + item.Vitality + "\nRarity : " + item.Rarity + "\nValue : " + item.Value ;
        }
        else if(item.Rarity == 2)
        {
            data = "<color=#00ff48><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n\nPower : " + item.Power + "\nDefence : " + item.Defence + "\nVitality : " + item.Vitality + "\nRarity : " + item.Rarity + "\nValue : " + item.Value;
        }
        else if(item.Rarity == 3)
        {
            data = "<color=#005aff><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n\nPower : " + item.Power + "\nDefence : " + item.Defence + "\nVitality : " + item.Vitality + "\nRarity : " + item.Rarity + "\nValue : " + item.Value;
        }
        else if(item.Rarity == 4)
        {
            data = "<color=#f30000><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n\nPower : " + item.Power + "\nDefence : " + item.Defence + "\nVitality : " + item.Vitality + "\nRarity : " + item.Rarity + "\nValue : " + item.Value;
        } 
        else if(item.Rarity == 5)
        {
            data = "<color=#f3ec35><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n\nPower : " + item.Power + "\nDefence : " + item.Defence + "\nVitality : " + item.Vitality + "\nRarity : " + item.Rarity + "\nValue : " + item.Value;
        }
        
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;

    }
}
