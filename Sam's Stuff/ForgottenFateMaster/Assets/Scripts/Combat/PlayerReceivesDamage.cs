using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerReceivesDamage : MonoBehaviour 
{
	public GameObject CBTPrefab;
	public GameObject _player;
	
	
	[HideInInspector]
	public int meleeHits; //howmany melee hits the player has been attacked with
	[HideInInspector]
	public int rangeHits; //howmany range hits the player has been attacked with
	//[HideInInspector]
	float hitChance;
	float defDex_calc;
	private float damageTaken;
	float criticalHit = 0f;

	
	
	// Use this for initialization
	void Start () 
	{

		
	}
	void Update()
	{


			//print ("Health" + _player.GetComponent<CombatScript> ().health);

	}
	
	
	//pysical damage
	void OnTriggerStay2D(Collider2D enemy)
	{
		if (enemy.gameObject.GetComponent<EnemiesReceiveDamage> () != null) 
		{
			if (meleeHits > 0) 
			{
				//print ("deal damage");
				hitChance = Random.Range (0.0f, 1.0f);
				defDex_calc = (enemy.gameObject.GetComponent<EnemiesReceiveDamage> ().dexterity - _player.GetComponent<CombatScript> ().dexterity) / enemy.gameObject.GetComponent<EnemiesReceiveDamage> ().dexterity;
				if (defDex_calc > 0.95f)
					defDex_calc = .95f;
				if (defDex_calc < 0.05f)
					defDex_calc = .05f;
				
				meleeHits -= 1;  //subbtracts from hits
				
				//	Debug.Log (defDex_calc);
				
				//causing damage and estimating chances
				
				if (hitChance <= 1 && (hitChance >= defDex_calc)) {
					damageTaken = 0;
					InitiateCBT ("*miss*").GetComponent<Animator> ().SetTrigger ("Miss");
					hitChance = 2;
					
				}
				if (hitChance <= 1 && (hitChance < defDex_calc)) {
					hitChance = 2;
					meleeHits -= 1;
					damageTaken = enemy.gameObject.GetComponent<EnemiesReceiveDamage> ().damage;
					if (damageTaken > _player.GetComponent<CombatScript> ().armor + 1)
						damageTaken = damageTaken - _player.GetComponent<CombatScript> ().armor;
					else
						damageTaken = 2;
					damageTaken = Random.Range (damageTaken * 0.7f, damageTaken);
					damageTaken = -damageTaken;
					criticalHit = Random.Range (0, 1.0f);
					//print ("crit" + criticalHit);
					
					//Damage caused by critical hit (critical hits do 5 times more than normal damage)
					if (criticalHit < 2 && criticalHit <= enemy.gameObject.GetComponent<EnemiesReceiveDamage> ().criticalChance) {
						damageTaken = (damageTaken * 5);
						damageTaken = Mathf.Round (damageTaken * 10f) / 10f;
						InitiateCBT(damageTaken.ToString()).GetComponent<Animator>().SetTrigger("Crit");
						//print ("damageTaken " + damageTaken);
						_player.GetComponent<CombatScript> ().health += damageTaken;
						//calculator = _player.GetComponent<CombatScript> ().health / _player.GetComponent<CombatScript> ().maxHealth;
						//SetHealth (calculator);
						criticalHit = 2;
						//sound
					}
					//Nomal damage
					if (criticalHit < 2 && criticalHit > _player.GetComponent<CombatScript> ().criticalChance) { // was originally criticalHit != _player.GetComponent<CombatScript>().criticalChance)
						damageTaken = Mathf.Round (damageTaken * 10f) / 10f;
						//print ("damageTaken " + damageTaken);
						InitiateCBT (damageTaken.ToString ()).GetComponent<Animator> ().SetTrigger ("Hit");
						_player.GetComponent<CombatScript> ().health += damageTaken;
						//calculator = hp / maxHp;
						//SetHealth (calculator);
						criticalHit = 2;
						//play sound here
					}
				}
			}
		}
	}
	GameObject InitiateCBT(string text)
	{
		GameObject temp = Instantiate (CBTPrefab) as GameObject;
		RectTransform tempRect = temp.GetComponent<RectTransform>();
		temp.transform.SetParent (transform.FindChild ("PlayerCanvas"));
		tempRect.transform.localPosition = CBTPrefab.transform.localPosition;
		tempRect.transform.localScale = CBTPrefab.transform.localScale;
		tempRect.transform.localRotation = CBTPrefab.transform.localRotation;
		
//		Debug.Log (tempRect.transform.localPosition);
		
		temp.GetComponent<Text>().text = text;
		Destroy(temp.gameObject, 3);
		//temp.GetComponent<Animator>().SetTrigger("Hit");
		return temp;
	}
}
