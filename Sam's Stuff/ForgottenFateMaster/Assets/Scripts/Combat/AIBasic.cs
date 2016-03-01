using UnityEngine;
using System.Collections;

public class AIBasic : MonoBehaviour {

	[HideInInspector]
	public float targetDistance;
	public float attackDistance;
	
	public float enemyMovementSpeed;
	[HideInInspector]
	public float slowMovementSpeed;
	[HideInInspector]
	public float fastMovementSpeed;
	
	public Transform target;
	
	public GameObject _player;
	
	private int	random;
	
	private float 	fleeHealth;
	
	bool	isNotTouching = true;
	bool	noDamage 	= true;
	bool	runAway 	= false;
	bool	stayFight	= true;

	// Use this for initialization
	void Start ()
	{
		fastMovementSpeed = enemyMovementSpeed * 2.0f;
		slowMovementSpeed = enemyMovementSpeed;
		
		fleeHealth = this.gameObject.GetComponent<EnemiesReceiveDamage> ().maxHp * .2f;
	}
	// Update is called once per frame
	void Update ()
	{
		targetDistance = Vector3.Distance (target.position, transform.position);

		//-------Speed Changes Based Upon Distance------------
		if (targetDistance > attackDistance / 2.5)
		{
			enemyMovementSpeed = fastMovementSpeed;
		} 
		else
			enemyMovementSpeed = slowMovementSpeed;

		//--------If Hit, always Chances------------
		if (noDamage) 
		{
			if (this.gameObject.GetComponent<EnemiesReceiveDamage> ().hp < this.gameObject.GetComponent<EnemiesReceiveDamage> ().maxHp) 
			{
				attackDistance = 1000;
				noDamage = false;
				print ("I;ve Been Hit!");
			}
		}

		//-------------Random Chance of Fleeing-------
		if (stayFight)
		{
			if (this.gameObject.GetComponent<EnemiesReceiveDamage> ().hp < fleeHealth)
			{
				stayFight = false;
				random = Random.Range (1, 5);
				print (random + ": Random Number");
				
				if (random == 1) {
					runAway = true;
				}
			}
		}

		//------Moves Towards the Player-------------
		if (targetDistance < attackDistance)
		{
			MovingPhase();
		}
	}

	void MovingPhase()
	{
		
		if (runAway) 
		{
			print ("RUN AWAY!");
			//---------Opposite of isNotTouching------------
			if (target.position.y > transform.position.y) {
				transform.position += transform.up * -enemyMovementSpeed * Time.deltaTime;
				//Debug.Log ("We;re going up!");
			} else {
				transform.position += transform.up * enemyMovementSpeed * Time.deltaTime;
				//Debug.Log ("We;re going down!");
			}
			
			if (target.position.x > transform.position.x) {
				transform.position += transform.right * -enemyMovementSpeed * Time.deltaTime;
				//Debug.Log ("We;re going right!!");
			} else {
				transform.position += transform.right * enemyMovementSpeed * Time.deltaTime;
				//Debug.Log ("We;re going left!");
			}
		}

		else if (isNotTouching) 
		{
			if (target.position.y > transform.position.y) 
			{
				transform.position += transform.up * enemyMovementSpeed * Time.deltaTime;
			} 
			else 
			{
				transform.position += transform.up * -enemyMovementSpeed * Time.deltaTime;
			}

			if (target.position.x > transform.position.x)
			{
				transform.position += transform.right * enemyMovementSpeed * Time.deltaTime;
			}
			else 
			{
				transform.position += transform.right * -enemyMovementSpeed * Time.deltaTime;
			}
		}
	}

	void OnCollisionStay2D(Collision2D playerC)
	{
		if (playerC.gameObject.tag == "Player") 
		{
			isNotTouching = false;
            target.GetComponent<PlayerReceivesDamage>().meleeHits++;
		}
	}

	void OnCollisionExit2D (Collision2D playerC)
	{
		isNotTouching = true;
	}
}