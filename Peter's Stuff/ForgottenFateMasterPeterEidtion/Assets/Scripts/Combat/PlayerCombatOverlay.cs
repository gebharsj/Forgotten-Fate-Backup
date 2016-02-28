using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCombatOverlay : MonoBehaviour {
	
	public Image healthBar;
	public Image manaBar;
	public Image expBar;

	private string healthCurrent;
	private string healthMax;

	private string manaCurrent;
	private string manaMax;

	private string expCurrent;
	private string expMax;
	private string playerLevel;

	public Text healthTextbox;
	public Text manaTexbox;

	public Text expCurrentTextbox;
	public Text expMaxTextbox;
	public Text playerLevelTextbox;

	float calculatorHealth;
	float calculatorMana;
	float calculatorExp;

	public Color32 startColorHealth;
	public Color32 startColorMana;
	public Color32 startColorExp;
	public Color32 endColor;

	private float placeHolder;

	public GameObject _player;

	void Update () 
	{
		//-------------Calculate the Ratio Between Current and Max-----------------------------------------------
		//print (_player.GetComponent<CombatScript> ().maxExp + " Max Exp");
		calculatorHealth = _player.GetComponent<CombatScript> ().health / _player.GetComponent<CombatScript> ().maxHealth;
		calculatorMana = _player.GetComponent<CombatScript> ().mana / _player.GetComponent<CombatScript> ().maxMana;
		calculatorExp = _player.GetComponent<CombatScript> ().exp / _player.GetComponent<CombatScript> ().maxExp;

		SetHealth (calculatorHealth);
		SetMana (calculatorMana);
		SetExp (calculatorExp);

		//print (calculatorExp + " Calc. EXP");
		//print (calculatorHealth + " Calc. Health");

		//--------------Convert Numbers to String-----------------
		placeHolder = _player.GetComponent<CombatScript> ().health;
		healthCurrent = placeHolder.ToString ();

		placeHolder = _player.GetComponent<CombatScript> ().maxHealth;
		healthMax = placeHolder.ToString ();

		placeHolder = _player.GetComponent<CombatScript> ().mana;
		manaCurrent = placeHolder.ToString ();

		placeHolder = _player.GetComponent<CombatScript> ().maxMana;
		manaMax = placeHolder.ToString ();
		
		placeHolder = _player.GetComponent<CombatScript> ().exp;
		expCurrent = placeHolder.ToString ();

		placeHolder = _player.GetComponent<CombatScript> ().maxExp;
		expMax = placeHolder.ToString ();

		placeHolder = _player.GetComponent<CombatScript> ().playerLevel;
		playerLevel = placeHolder.ToString ();

		//-----------------Print the Health and Mana--------
		healthTextbox.text = healthCurrent + " /  " + healthMax;
		manaTexbox.text = manaCurrent + " / " + manaMax;

		//-----------------Print the EXP and Current Level-------

		expCurrentTextbox.text = expCurrent + " / ";
		expMaxTextbox.text = expMax;
		playerLevelTextbox.text = "Current Level: " + playerLevel;

	}
	//-------------Setting the Look of the Health Bar------------------
	public void SetHealth (float myHealth)
	{
		//"myHealth" needs to be set between the values of 0 and 1: 1 being 100%.
		healthBar.transform.localScale = new Vector3 (myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
		//healthBar.color = Color.Lerp(endColor, startColorHealth, calculatorHealth);
	}
	//-------------Setting the Look of the Mana Bar------------------
	public void SetMana(float myMana)
	{
		manaBar.transform.localScale = new Vector3 (myMana, manaBar.transform.localScale.y, manaBar.transform.localScale.z);
		//manaBar.color = Color.Lerp(startColorMana, endColor, calculatorMana);
	}
	//-------------Setting the Look of the Exp Bar------------------
	public void SetExp(float myExp)
	{
		expBar.transform.localScale = new Vector3 (myExp, expBar.transform.localScale.y, expBar.transform.localScale.z);
		//expBar.color = Color.Lerp(endColor, startColorExp, calculatorExp);
	}
}