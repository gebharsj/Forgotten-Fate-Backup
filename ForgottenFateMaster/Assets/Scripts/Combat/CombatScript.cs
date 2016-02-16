using UnityEngine;
using System.Collections;

public class CombatScript : MonoBehaviour 
{
	public GameObject self;
	public GameObject up;
	public GameObject down;
	public GameObject left;
	public GameObject right;
	public float maxMana;
	public float manaRecovery = 0.03f;
	private float mana;
	public float normalDamage = 3;
	[HideInInspector]
	public float playerDamage = 3;
	public float attackSpeed = 5.0f;
	public int defense;
	public int armor;
	public float dexterity; // chance of hitting
	public float meleeRange = 0.8f;
	public float meleeAdjustment = 0.5f;
	public int maxHealth = 65;
	float health;
	public float criticalChance = 0.03f;
	private float chargeMultiplier = 10.0f;
	[HideInInspector]
	public float chargeDistance;
	
	
	[HideInInspector]
	public int splash;
	[HideInInspector]
	public float attackRate;  //rate of attack
	
	void Awake()
	{
		mana = maxMana;
		health = maxHealth;
	}
	
	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health == 0)
		{
			Destroy (gameObject);
			//pay animation
			//play sound
		}
		
		
		
		//setting the scale of objects to range of melee weapon
		up.transform.localScale = new Vector3(0, meleeRange, 0);
		up.transform.localPosition = new Vector3(0, meleeAdjustment, 0);
		down.transform.localScale = new Vector3(0, -meleeRange, 0);
		down.transform.localPosition = new Vector3(0, -meleeAdjustment, 0);
		left.transform.localScale = new Vector3(-meleeRange, 0, 0);
		left.transform.localPosition = new Vector3(-meleeAdjustment, 0, 0);
		right.transform.localScale = new Vector3(meleeRange, 0, 0);
		right.transform.localPosition = new Vector3(meleeAdjustment, 0, 0);
		
		if (criticalChance > 0.08f)
			criticalChance = 0.08f;
		
		
		if(Input.GetMouseButtonDown(0) && attackRate == 0)  //left click
		{
			if (!self.GetComponent<PlayerMovement>().isSprinting)
			{
				playerDamage = normalDamage;
				splash = 1; 
				attackRate = 5;
				
				//the value of this variable determines how many foes can be hit in a single attack
				//since it's currently set to 1, only one foe can be hit at a time.
				//certain spells, such as a multi attack, will require this variable to increase.
				
				//play sound
				//attack animation
			}
			if (self.GetComponent<PlayerMovement>().isSprinting)
			{
				playerDamage = normalDamage * chargeMultiplier;
				splash = 5; 
				chargeDistance = 1.2f;
				self.GetComponent<PlayerMovement>().moveX = self.GetComponent<PlayerMovement>().moveX * 25;
				self.GetComponent<PlayerMovement>().moveY = self.GetComponent<PlayerMovement>().moveY * 25;
				
			}
		}
		
		//attack speed
		if (attackRate > 0)
		{
			attackRate -= attackSpeed * Time.deltaTime;
			//prevents moving during attack
			self.GetComponent<PlayerMovement>().moveX = 0;
			self.GetComponent<PlayerMovement>().moveY = 0;
		}
		
		if(attackRate < 0)
			attackRate = 0;
		if(attackSpeed > 50)
			attackSpeed = 50;
		
		//mana recovery
		if (mana < maxMana) 
			mana += manaRecovery * Time.deltaTime;
		
		if (defense < 1)
			defense = 1;
		
		//charge recovery
		if (chargeDistance > 1) 
			chargeDistance -= chargeDistance * Time.deltaTime;
		
		if (chargeDistance > 0 && chargeDistance <= 1) 
		{
			attackRate = 10;
			chargeDistance = 0;
		}
		
		
		
		//casting magic
		if(Input.GetMouseButtonDown(1))  //right click
		{
			
		}
		
		//facing right
		if (self.GetComponent<PlayerMovement>().moveX > 0)
		{
			up.SetActive (false);
			down.SetActive (false);
			left.SetActive (false);
			right.SetActive (true);
		}
		//facing left
		if (self.GetComponent<PlayerMovement>().moveX < 0)
		{
			up.SetActive (false);
			down.SetActive (false);
			left.SetActive (true);
			right.SetActive (false);
		}
		//facing up
		if (self.GetComponent<PlayerMovement>().moveY > 0)
		{
			up.SetActive (true);
			down.SetActive (false);
			left.SetActive (false);
			right.SetActive (false);
		}
		//facing down
		if (self.GetComponent<PlayerMovement>().moveY < 0)
		{
			up.SetActive (false);
			down.SetActive (true);
			left.SetActive (false);
			right.SetActive (false);
		}
	}
	IEnumerator WaitAndPrint(float waitTime)
	{
		yield return new WaitForSeconds(0.5f);
	}
}

