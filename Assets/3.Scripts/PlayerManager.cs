using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    private int playerMaxStamina;
    private int currentStamina;
    private int playerTempLevel;
    private int playerLevel;
    private int useStamina;

    private float maxExp;
    private float currentExp;

    public Slider staminaSlider;
    public Slider expSlider;

    public Text staminaText;
    public Text expText;
    public Text levelText;

    public Text timeText;

    private float currStaminaTime;
    private float maxTime;
    private int recoverStamina;

	// Use this for initialization
	void Start () {

        maxTime = 10f;
        recoverStamina = 1;
        currStaminaTime = maxTime;


        playerLevel = 1;
        useStamina = 5;
        playerTempLevel = playerLevel;
        playerMaxStamina = 30;
        currentStamina = playerMaxStamina;

        PlayerState.getInstance.SetPlayerState(1,30,100);

        staminaSlider.value = currentStamina;
        expSlider.value = 0;

        maxExp = 100;
        currentExp = 0;
        

       // staminaSlider = GetComponent<Slider>();

	}
	
	// Update is called once per frame
	void Update () {
       // ExpTable();

        Exp();
        PlayerStates();
        StaminaTime();
	}

    void PlayerStates()
    {
        staminaSlider.maxValue = (float)PlayerState.getInstance.playerMaxStamina;
        staminaSlider.value = (float)PlayerState.getInstance.currentStamina;

        expText.text = string.Format("{0}/{1}", (int)PlayerState.getInstance.currentExp, (int)PlayerState.getInstance.maxExp);
        staminaText.text = string.Format("{0}/{1}", PlayerState.getInstance.currentStamina, PlayerState.getInstance.playerMaxStamina);

        levelText.text = string.Format("{0}",PlayerState.getInstance.playerLevel);
    }

    void StaminaTime()
    {

        currStaminaTime  -= Time.deltaTime;

        timeText.text = string.Format("{0} : {1:00}", (int)currStaminaTime / 60, (int)currStaminaTime % 60);


        if (currStaminaTime <= 0)
        {
            currStaminaTime = maxTime + 1;
            
            if(PlayerState.getInstance.currentStamina < PlayerState.getInstance.playerMaxStamina)
            {
                recoverStamina = 1;
                PlayerState.getInstance.currentStamina += recoverStamina;
            }
            else
            {
                recoverStamina = 0;
            }
        }

    }

    public void SetUseStamina(int _useStamina)
    {
        PlayerState.getInstance.useStamina = _useStamina;
    }

    public void GetUseStamina()
    {
        staminaSlider.value = PlayerState.getInstance.currentStamina;

        if (PlayerState.getInstance.currentStamina >= PlayerState.getInstance.useStamina)
        {
            PlayerState.getInstance.currentStamina -= PlayerState.getInstance.useStamina;
            PlayerState.getInstance.useStamina = 5;
            return;
        }
        else if (PlayerState.getInstance.currentStamina < PlayerState.getInstance.useStamina)
        {
            PlayerState.getInstance.useStamina = 0;
        }

        
    }


    void Exp()
    {
        //Exp and Stamina Test Code
        if (Input.GetKey(KeyCode.A))
        {
            PlayerState.getInstance.currentExp += 20;
            expSlider.value = PlayerState.getInstance.currentExp;

            Debug.Log("currentExp : " + PlayerState.getInstance.currentExp);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            staminaSlider.value = PlayerState.getInstance.currentStamina;

            if (PlayerState.getInstance.currentStamina >= useStamina)
            {
                PlayerState.getInstance.currentStamina -= useStamina;
                useStamina = 5;                
                return;
            }
            else if (PlayerState.getInstance.currentStamina < useStamina)
            {
                useStamina = 0;
            }           
            
        }

        if (PlayerState.getInstance.currentExp >= PlayerState.getInstance.maxExp)
        {
            PlayerState.getInstance.playerTempLevel = PlayerState.getInstance.playerLevel;
            ++PlayerState.getInstance.playerLevel;

            PlayerState.getInstance.currentExp = 0;
            Debug.Log("maxExpcurrentExp : " + PlayerState.getInstance.currentExp);
            if (PlayerState.getInstance.playerLevel <= 10)
            {
                PlayerState.getInstance.maxExp = (100 * PlayerState.getInstance.playerLevel - PlayerState.getInstance.maxExp * 60 / 100) + PlayerState.getInstance.maxExp;
            }
            else if (PlayerState.getInstance.playerLevel > 10 && PlayerState.getInstance.playerLevel <= 40)
            {
                PlayerState.getInstance.maxExp = (115 * PlayerState.getInstance.playerLevel - PlayerState.getInstance.maxExp * 45 / 100) + PlayerState.getInstance.maxExp;
            }
            else if (PlayerState.getInstance.playerLevel > 40 && PlayerState.getInstance.playerLevel <= 100)
            {
                PlayerState.getInstance.maxExp = (138 * PlayerState.getInstance.playerLevel - PlayerState.getInstance.maxExp * 40 / 100) + PlayerState.getInstance.maxExp;
            }
        }
        if (PlayerState.getInstance.playerLevel > PlayerState.getInstance.playerTempLevel)
        {
            PlayerState.getInstance.playerMaxStamina += 2;
            staminaSlider.value = PlayerState.getInstance.playerMaxStamina;
            PlayerState.getInstance.currentStamina = PlayerState.getInstance.playerMaxStamina;

            expSlider.maxValue = PlayerState.getInstance.maxExp;
            expSlider.value = 0;

            ++PlayerState.getInstance.playerTempLevel;
        }

        Debug.Log("playerLevel : " + PlayerState.getInstance.playerLevel);
    }


    //void ExpTable()
    //{
    //    if (playerLevel <= 10)
    //    {
    //        for (; playerLevel <= 10; playerLevel++)
    //        {
    //            maxExp = (100 * playerLevel - maxExp * 60 / 100) + maxExp;
    //            Debug.Log(playerLevel + " : " + (int)maxExp);         
    //        }
    //    }
    //    if (playerLevel > 10 && playerLevel <= 40)
    //    {
    //        for (; playerLevel <= 40; playerLevel++)
    //        {
    //            maxExp = (115 * playerLevel - maxExp * 45 / 100) + maxExp;
    //            Debug.Log(playerLevel + " : " + (int)maxExp);   

    //        }
    //    }
    //    if (playerLevel > 40 && playerLevel <= 100)
    //    {
    //        for (; playerLevel <= 100; playerLevel++)
    //        {
    //            maxExp = (138 * playerLevel - maxExp * 40 / 100) + maxExp;
    //            Debug.Log(playerLevel + " : " + (int)maxExp);
    //        }
    //    }
    //}
}

public class PlayerState : Singleton_OBJ<PlayerState>
{
    public int playerMaxStamina { get; set; }
    public int currentStamina { get; set; }
    public int playerTempLevel { get; set; }
    public int playerLevel { get; set; }
    public int useStamina { get; set; }

    public float maxExp { get; set; }
    public float currentExp { get; set; }


    

    public void SetPlayerState(int _level, int _maxStamina, float _maxExp)
    {
        this.playerLevel = _level;
        this.playerTempLevel = playerLevel;
        this.playerMaxStamina = _maxStamina;
        this.currentStamina = playerMaxStamina;

        this.maxExp = _maxExp;
        this.currentExp = 0;

    }



    public PlayerState()
    {
    }

}