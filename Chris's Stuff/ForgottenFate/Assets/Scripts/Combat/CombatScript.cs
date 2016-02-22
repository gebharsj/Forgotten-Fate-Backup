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
	public float normalDamage = 7;
	public float rangeDamage = 3;
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
	private bool melee = true;
	public Rigidbody projectile;
	[HideInInspector]
	public Transform target;
	
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
	


		//switching from melee to range
		if (Input.GetKeyUp(KeyCode.E))
	 {
			if (melee == false)
			{
				melee = true;
				//print ("true");
			}
			//switching from range to melee
			else
			{
				melee = false;
				//print ("false");
			}
	}
		


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
		
		
		if (Input.GetMouseButtonDown (0) && attackRate == 0) //left click
		{ 

			if (melee == true)
			{
				if (!self.GetComponent<PlayerMovement> ().isSprinting) 
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
				if (self.GetComponent<PlayerMovement> ().isSprinting)
				{
					playerDamage = normalDamage * chargeMultiplier;
					splash = 5; 
					chargeDistance = 1.2f;
					self.GetComponent<PlayerMovement> ().moveX = self.GetComponent<PlayerMovement> ().moveX * 25;
					self.GetComponent<PlayerMovement> ().moveY = self.GetComponent<PlayerMovement> ().moveY * 25;
				
				}
			}
			if (melee == false)
			{

				if (!target)
				target = GameObject.FindWithTag ("Mouse").transform;
				Vector3 pos;
				pos = new Vector3 (Random.Range (-0.8f, 1.2f), Random.Range (-0.8f, 1.2f), 0);

				playerDamage = rangeDamage;
				attackRate = 4;
				Rigidbody clone;
				clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;

				Vector3 v3Pos;
				float fAngle;
				
				v3Pos = Camera.main.WorldToScreenPoint(target.transform.position);
				v3Pos = Input.mousePosition - v3Pos;
				fAngle = Mathf.Atan2 (v3Pos.y, v3Pos.x)* Mathf.Rad2Deg;
				if (fAngle < 0.0f) fAngle += 360.0f;
		//		Debug.Log ("3" +fAngle);  

					//detecting arrow direction witht he variable direction
					if (fAngle <= 315.0F && fAngle > 225.0F)
					{
						print ("up");
						clone.velocity = (GameObject.Find("Mouse").transform.position + pos).normalized * Random.Range (10,14);
						down.SetActive (false);
						left.SetActive (false);
						right.SetActive (false);
						up.SetActive (true);
					}
					if (fAngle <= 225.0F && fAngle > 135.0F)
					{
						print ("right");
						clone.velocity = (GameObject.Find("Mouse").transform.position + pos).normalized * Random.Range (10,14);
						up.SetActive (false);
						down.SetActive (false);
						left.SetActive (false);
						right.SetActive (true);
					}
					if (fAngle <= 45.0F || fAngle > 315.0F)
					{
						print ("left");
						clone.velocity = (GameObject.Find("Mouse").transform.position + pos).normalized * Random.Range (10,14);
						up.SetActive (false);
						down.SetActive (false);
						right.SetActive (false);
						left.SetActive (true);
					}
					if (fAngle <= 135.0F && fAngle > 45.0F)
					{
						print ("down");
					clone.velocity = (GameObject.Find("Mouse").transform.position + pos).normalized * Random.Range (10,14); 
						up.SetActive (false);
						left.SetActive (false);
						right.SetActive (false);
						down.SetActive (true);
				
					}
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


}
