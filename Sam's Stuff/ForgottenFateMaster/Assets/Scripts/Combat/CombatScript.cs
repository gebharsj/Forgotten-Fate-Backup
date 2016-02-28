using UnityEngine;
using System.Collections;

public class CombatScript : MonoBehaviour 
{
	public GameObject self;
	public Transform playerPOS;
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
	[HideInInspector]
	public float fireDamage = 0.1f;
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
	public bool melee = true;
	public Rigidbody2D projectile;
	public Rigidbody2D flamePrefab;
	[HideInInspector]
	public Transform target;
	public GameObject smokeChild;


	
	[HideInInspector]
	public int splash;
	[HideInInspector]
	public float attackRate;  //rate of attack



    //----------EXP--------
    [HideInInspector]
    public float exp;
    public int playerLevel = 1;


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
		if (Input.GetKeyUp(KeyCode.Q))
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
				//attack whie sprint is not active (normal attack)
				if (!self.GetComponent<PlayerMovement> ().isSprinting) 
				{
					playerDamage = normalDamage;
					splash = 1; 
					attackRate = 5;
					
					//the value of this variable,splash, determines how many foes can be hit within a single attack
					//since it's currently set to 1, only one foe can be hit at a time.
					//certain spells, such as a multi attack, will require this variable to increase.
					
					//play sound
					//attack animation
				}

				//attack during sprint (Dash attack)
				if ((self.GetComponent<PlayerMovement> ().isSprinting) && (self.GetComponent<PlayerMovement> ().moveX != 0 || self.GetComponent<PlayerMovement> ().moveY != 0))
				{
					chargeDistance = 1.2f;
					Vector3 playerPOS = self.transform.position;
					smokeChild.transform.position = playerPOS;
					playerDamage = normalDamage * chargeMultiplier;
					splash = 5; 
					self.GetComponent<PlayerMovement> ().moveX = self.GetComponent<PlayerMovement> ().moveX * 25;
					self.GetComponent<PlayerMovement> ().moveY = self.GetComponent<PlayerMovement> ().moveY * 25;
					smokeChild.SetActive(true);
				
				}
			}
			//using arrows
			if (melee == false)
			{

				if (!target)
				target = GameObject.FindWithTag ("Mouse").transform;


				playerDamage = rangeDamage;
				attackRate = 4;

                Vector3 v3Pos;
                float fAngle;

                v3Pos = Camera.main.WorldToScreenPoint(target.transform.position);
                v3Pos = Input.mousePosition - v3Pos;
                fAngle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
                if (fAngle < 0.0f) fAngle += 360.0f;
                
               //instantiate projectile
                Rigidbody2D clone;
                clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
                

               //detecting arrow direction with the variable direction
                if (fAngle <= 135.0F && fAngle > 45.0F)
					{
						print ("up");
						clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range (10,14);
						down.SetActive (false);
						left.SetActive (false);
						right.SetActive (false);
						up.SetActive (true);
					}
                if (fAngle <= 45.0F || fAngle > 315.0F)
					{
						print ("right");
						clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position ).normalized * Random.Range (10,14);
						up.SetActive (false);
						down.SetActive (false);
						left.SetActive (false);
						right.SetActive (true);
					}
					if (fAngle <= 225.0F && fAngle > 135.0F)
					{
						print ("left");
						clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range (10,14);
						up.SetActive (false);
						down.SetActive (false);
						right.SetActive (false);
						left.SetActive (true);
					}
                if (fAngle <= 315.0F && fAngle > 225.0F)
                    {
						print ("down");
					    clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range (10,14); 
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
		if(Input.GetMouseButton(1))  //right click
		{
			//prevent player from moving
			self.GetComponent<PlayerMovement>().moveX = 0;
			self.GetComponent<PlayerMovement>().moveY = 0;




			if (!target)
				target = GameObject.FindWithTag ("Mouse").transform;



			Vector3 v3Pos;
			float fAngle;
			
			v3Pos = Camera.main.WorldToScreenPoint(target.transform.position);
			v3Pos = Input.mousePosition - v3Pos;
			fAngle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;

			Rigidbody2D clone;
			clone = Instantiate(flamePrefab, transform.position, transform.rotation) as Rigidbody2D;

			if (fAngle < 0.0f) 
				fAngle += 360.0f;

			//flame goes in the direction of the mouse

			
			
			if (fAngle <= 135.0F && fAngle > 45.0F)
			{
				print ("up");
				clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range (3,5);
				down.SetActive (false);
				left.SetActive (false);
				right.SetActive (false);
				up.SetActive (true);
			}
			if (fAngle <= 45.0F || fAngle > 315.0F)
			{
				print ("right");
				clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range (3,5);
				up.SetActive (false);
				down.SetActive (false);
				left.SetActive (false);
				right.SetActive (true);
			}
			if (fAngle <= 225.0F && fAngle > 135.0F)
			{
				print ("left");
				clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range (3,5);
				up.SetActive (false);
				down.SetActive (false);
				right.SetActive (false);
				left.SetActive (true);
			}
			if (fAngle <= 315.0F && fAngle > 225.0F)
			{
				print ("down");
				clone.velocity = (GameObject.Find("Mouse").transform.position - transform.position).normalized * Random.Range (3,5);
				up.SetActive (false);
				left.SetActive (false);
				right.SetActive (false);
				down.SetActive (true);
				
			}
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


	//deactivating smokeChild

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Smoke" && chargeDistance <= 0)
		{
			smokeChild.SetActive(false);
			
		}


	}
}
