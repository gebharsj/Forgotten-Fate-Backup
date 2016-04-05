using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCombatOverlay : MonoBehaviour {

    public Image healthBar;
    public Image healthDrain;
    public Image staminaBar;
    public Image expBar;

    private string healthCurrent;
    private string healthMax;

    private string staminaCurrent;
    private string staminaMax;

    private string expCurrent;
    private string expMax;
    private string playerLevel;

    public Text healthTextbox;
    public Text staminaTextbox;

    public Text expCurrentTextbox;
    public Text expMaxTextbox;
    public Text playerLevelTextbox;

    float calculatorHealth;
    float calculatorDrain;
    float calculatorStamina;
    float calculatorExp;
    float drain;

    public Color32 startColorHealth;
    public Color32 startColorStamina;
    public Color32 startColorExp;
    public Color32 endColor;

    private float placeHolder;

    public GameObject _player;

    void Start()
    {
        drain = _player.GetComponent<CombatScript>().health;
    }


    void Update()
    {
        //health drain effect
        if (drain > _player.GetComponent<CombatScript>().health)
        {

            drain -= 20 * Time.deltaTime;
            calculatorDrain = drain / _player.GetComponent<CombatScript>().maxHealth;
            SetDrain(calculatorDrain);
        }
        if (drain < _player.GetComponent<CombatScript>().health)
        {
            drain = _player.GetComponent<CombatScript>().health;
            calculatorDrain = drain / _player.GetComponent<CombatScript>().maxHealth;
            SetDrain(calculatorDrain);
        }





        //-------------Calculate the Ratio Between Current and Max-----------------------------------------------
        //print (_player.GetComponent<CombatScript> ().maxExp + " Max Exp");
        calculatorHealth = _player.GetComponent<CombatScript>().health / _player.GetComponent<CombatScript>().maxHealth;
        calculatorStamina = _player.GetComponent<PlayerMovement>().stamina / _player.GetComponent<PlayerMovement>().maxStamina;
        calculatorExp = _player.GetComponent<ExpSystemPlayer>().exp / _player.GetComponent<ExpSystemPlayer>().maxExp;

        SetHealth(calculatorHealth);
        SetStamina(calculatorStamina);
        SetExp(calculatorExp);

        //print (calculatorExp + " Calc. EXP");
        //print (calculatorHealth + " Calc. Health");

        //--------------Convert Numbers to String-----------------
        placeHolder = _player.GetComponent<CombatScript>().health;
        placeHolder = placeHolder * 10;
        placeHolder = Mathf.Round(placeHolder);
        placeHolder = placeHolder / 10;
        healthCurrent = placeHolder.ToString();

        placeHolder = _player.GetComponent<CombatScript>().maxHealth;
        healthMax = placeHolder.ToString();

        placeHolder = _player.GetComponent<PlayerMovement>().stamina * 100;
        placeHolder = placeHolder / _player.GetComponent<PlayerMovement>().maxStamina;
        placeHolder = placeHolder * 1;
        placeHolder = Mathf.Round(placeHolder);
        placeHolder = placeHolder / 1;
        staminaCurrent = placeHolder.ToString();

        placeHolder = _player.GetComponent<PlayerMovement>().maxStamina;
        staminaMax = placeHolder.ToString();

        placeHolder = _player.GetComponent<ExpSystemPlayer>().exp;
        expCurrent = placeHolder.ToString();

        placeHolder = _player.GetComponent<ExpSystemPlayer>().maxExp;
        expMax = placeHolder.ToString();

        placeHolder = _player.GetComponent<ExpSystemPlayer>().playerLevel;
        playerLevel = placeHolder.ToString();

        //-----------------Print the Health and Mana--------
        healthTextbox.text = healthCurrent + " /  " + healthMax;
        staminaTextbox.text = staminaCurrent + "%";

        //-----------------Print the EXP and Current Level-------

        expCurrentTextbox.text = expCurrent + " / ";
        expMaxTextbox.text = expMax;
        playerLevelTextbox.text = "Level: " + playerLevel;

    }
    //-------------Setting the Look of the Health Bar------------------
    public void SetHealth(float myHealth)
    {
        //"myHealth" needs to be set between the values of 0 and 1: 1 being 100%.
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        //healthBar.color = Color.Lerp(endColor, startColorHealth, calculatorHealth);
    }
    //-------------Setting the Look of the Mana Bar------------------
    public void SetStamina(float myStamina)
    {
        staminaBar.transform.localScale = new Vector3(myStamina, staminaBar.transform.localScale.y, staminaBar.transform.localScale.z);
        //manaBar.color = Color.Lerp(startColorMana, endColor, calculatorMana);
    }
    //-------------Setting the Look of the Exp Bar------------------
    public void SetExp(float myExp)
    {
        expBar.transform.localScale = new Vector3(myExp, expBar.transform.localScale.y, expBar.transform.localScale.z);
        //expBar.color = Color.Lerp(endColor, startColorExp, calculatorExp);
    }
    public void SetDrain(float myDrain)
    {
        healthDrain.transform.localScale = new Vector3(myDrain, healthDrain.transform.localScale.y, healthDrain.transform.localScale.z);
        //manaBar.color = Color.Lerp(startColorMana, endColor, calculatorMana);
    }
}