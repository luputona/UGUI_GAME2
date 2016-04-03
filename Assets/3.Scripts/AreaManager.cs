using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using LitJson;

public class AreaManager : MonoBehaviour {

    private List<AreaInfo> lAreaInfo = new List<AreaInfo>();
    private JsonData AreaData;    
    private int useStamina;
    //private Dictionary<>();
    public PlayerManager playerMgr;

    public Text areaNameText;
    public Text areaInfoText;

	// Use this for initialization
	void Start ()
    {
        //playerMgr = GetComponent<PlayerManager>();
        
        AreaData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Areas.json"));
        ConstructItemDatabase();
        

    }
    void Update()
    {

    }

    public void Button()
    {
        playerMgr.SetUseStamina(useStamina);
        playerMgr.GetUseStamina();
    }

    

	
	public AreaInfo FetchAreaByID(int id)
    {
        for (int i = 0; i < lAreaInfo.Count; i++)
        {
            if (lAreaInfo[i].ID == id)
            {
                return lAreaInfo[i];
            }
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < AreaData.Count; i++)
        {
            lAreaInfo.Add(new AreaInfo((int)AreaData[i]["ID"], (int)AreaData[i]["FieldNum"], (int)AreaData[i]["AreaNum"], AreaData[i]["AreaName"].ToString(), (int)AreaData[i]["Consumestamina"]));

        }

    }

    public void ExplainArea(int _areaNum)
    {

        if(_areaNum == 1)
        {
            //lAreaInfo.Add(new AreaInfo(1, 1, "Seongnam-Daero 1139Beon-gil", 3));
            areaNameText.text = string.Format("{0}-{1} Area Name \n {2}",FetchAreaByID(1).FieldNum,FetchAreaByID(1).AreaNum, FetchAreaByID(1).AreaName);
            areaInfoText.text = string.Format("ConsumeStamina \n {0}", FetchAreaByID(1).ConsumeStamina);
            useStamina = FetchAreaByID(1).ConsumeStamina;
        }
        else if(_areaNum == 2)
        {
            //lAreaInfo.Add(new AreaInfo(1, 2, "Seongnam-Daero 1148Beon-gil", 3));
            areaNameText.text = string.Format("{0}-{1} Area Name \n {2}", FetchAreaByID(2).FieldNum, FetchAreaByID(2).AreaNum, FetchAreaByID(2).AreaName);
            areaInfoText.text = string.Format("ConsumeStamina \n {0}", FetchAreaByID(2).ConsumeStamina);
            useStamina = FetchAreaByID(2).ConsumeStamina;
        }
        else if(_areaNum == 3)
        {
            //lAreaInfo.Add(new AreaInfo(1, 2, "Seongnam-Daero 1140Beon-gil", 3));
            areaNameText.text = string.Format("{0}-{1} Area Name \n {2}", FetchAreaByID(3).FieldNum, FetchAreaByID(3).AreaNum, FetchAreaByID(3).AreaName);
            areaInfoText.text = string.Format("ConsumeStamina \n {0}", FetchAreaByID(3).ConsumeStamina);
            useStamina = FetchAreaByID(3).ConsumeStamina;
        }
        else if(_areaNum == 4)
        {
            //lAreaInfo.Add(new AreaInfo(1, 2, "Jeil-ro 35beon-gil", 3));
            areaNameText.text = string.Format("{0}-{1} Area Name \n {2}", FetchAreaByID(4).FieldNum, FetchAreaByID(4).AreaNum, FetchAreaByID(4).AreaName);
            areaInfoText.text = string.Format("ConsumeStamina \n {0}", FetchAreaByID(4).ConsumeStamina);
            useStamina = FetchAreaByID(4).ConsumeStamina;
        }
    }
}

public class AreaInfo
{
    //private int fieldNum;
    //private int areaNum;
    //private string areaName;
    //private int consumeStamina;

    public int ID {get; set;}
    public int FieldNum { get; set; }
    public int AreaNum { get; set; }
    public string AreaName { get; set; }
    public int ConsumeStamina { get; set; }

    public AreaInfo(int _id, int _fieldnum, int _areanum, string _areaname, int _consumestamina)
    {
        this.ID = _id;
        this.FieldNum = _fieldnum;
        this.AreaNum = _areanum;
        this.AreaName = _areaname;
        this.ConsumeStamina = _consumestamina;
    }
    public AreaInfo()
    {
        this.ID = -1;
    }


}