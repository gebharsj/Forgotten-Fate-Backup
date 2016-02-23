using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCombatOverlay : MonoBehaviour {
	
	public Image healthBar;
	public Image manaBar;
	public Image expBar;
	float calculatorHealth;
	float calculatorMana;
	float calculatorExp;
	public Color32 startColorHealth;
	public Color32 startColorMana;
	public Color32 startColorExp;
	public Color32 endColor;

	public GameObject _player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update () 
	{
		print (_player.GetComponent<CombatScript> ().maxExp + " Max Exp");
		calculatorHealth = _player.GetComponent<CombatScript> ().health / _player.GetComponent<CombatScript> ().maxHealth;
		calculatorMana = _player.GetComponent<CombatScript> ().mana / _player.GetComponent<CombatScript> ().maxMana;
		calculatorExp = _player.GetComponent<CombatScript> ().exp / _player.GetComponent<CombatScript> ().maxExp;

		SetHealth (calculatorHealth);
		SetMana (calculatorMana);
		SetExp (calculatorExp);

		print (calculatorExp + " Calc. EXP");
		print (calculatorHealth + " Calc. Health");
	}

	public void SetHealth (float myHealth)
	{
		print (myHealth + " Set Health Ratio");
		//"myHealth" needs to be set between the values of 0 and 1: 1 being 100%.
		healthBar.transform.localScale = new Vector3 (myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
		healthBar.color = Color.Lerp(endColor, startColorHealth, calculatorHealth);
	}

	public void SetMana(float myMana)
	{
		print (myMana + " Set Mana Ratio");
		//"myHealth" needs to be set between the values of 0 and 1: 1 being 100%.
		manaBar.transform.localScale = new Vector3 (myMana, manaBar.transform.localScale.y, manaBar.transform.localScale.z);
		manaBar.color = Color.Lerp(endColor, startColorMana, calculatorMana);
	}

	public void SetExp(float myExp)
	{
		print (myExp + " Set Exp Ratio");
		//"myHealth" needs to be set between the values of 0 and 1: 1 being 100%.
		expBar.transform.localScale = new Vector3 (.95f, expBar.transform.localScale.y, expBar.transform.localScale.z);
		expBar.color = Color.Lerp(endColor, startColorExp, calculatorExp);
	}
}
