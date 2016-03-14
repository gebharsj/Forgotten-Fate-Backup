using UnityEngine;
using System.Collections;

public class AiIntermediate : MonoBehaviour {

	[HideInInspector]
	public float targetDistance;
	public float attackDistance;

	public float sprintDistance;
	
	public float normalMovementSpeed;
	public float sprintMovementSpeed;
	[HideInInspector]
	public float slowMovementSpeed;
	[HideInInspector]
	public float fastMovementSpeed;
	
	private int	random;
	public float attackTimer;
	private float permentTimer;

	//private int		fleeNumber;
	//public 	int		fleePercent;
	public 	float 	fleeHealthPercent;
	private float 	fleeHealth;

	private float	objectHeight;
	private float 	objectWidth;

	public Transform targetPlayer;
	public Transform targetObject;
	public Transform targetRayCast;
	
	public GameObject _player;
	public GameObject _enemy;
	//-------Testing-----
	public GameObject _destination;

	private Vector3 vectorPoint1;
	private Vector3 vectorPoint2;
	private Vector3 vectorPoint3;
	private Vector3 vectorPoint4;
	private Vector3 vectorPoint5;
	private Vector3 vectorPoint6;
	private Vector3 vectorPoint7;
	private Vector3 vectorPoint8;

	public Transform _self;

	public Collider2D _collider;
	public Collider2D _ownCollider;

	private RaycastHit2D hit;

	//--------bools for direction-----
	bool 	movingUp	= true;
	bool	movingRight	= true;

	bool	playerTouch = false;
	bool	objectTouch = false;

	bool	noDamage 	= true;
	bool	runAway 	= false;
	bool	enemyTouch  = false;
	bool 	obstacleNav	= false;
	bool	enemyNav	= false;

	// Use this for initialization
	void Start ()
	{
		fastMovementSpeed = sprintMovementSpeed;
		slowMovementSpeed = normalMovementSpeed;

		permentTimer = attackTimer;

		fleeHealth = this.gameObject.GetComponent<EnemiesReceiveDamage> ().maxHp * fleeHealthPercent / 100;
	}

	// Update is called once per frame
	void Update ()
	{
		if (attackTimer > 0) 
		{
			//print (attackTimer + " : AttackTimer");
			attackTimer -= 1 * Time.deltaTime;
		}

		targetDistance = Vector3.Distance (targetPlayer.position, transform.position);

		//-------Speed Changes Based Upon Distance------------
		if (targetDistance > sprintDistance)
		{
			normalMovementSpeed = fastMovementSpeed;
		} 
		else
			normalMovementSpeed = slowMovementSpeed;

		//--------If Hit, always Chances------------
		if (noDamage) 
		{
			if (this.gameObject.GetComponent<EnemiesReceiveDamage> ().hp < this.gameObject.GetComponent<EnemiesReceiveDamage> ().maxHp) 
			{
				attackDistance = 1000;
				noDamage = false;
				//print ("I've Been Hit!");
			}
		}
		
		//-------------Random Chance of Fleeing-------
		if (runAway == false)
		{
			random = 0;
			if (this.gameObject.GetComponent<EnemiesReceiveDamage> ().hp < fleeHealth)
			{
				random = Random.Range (1, 1);//fleeNumber);

				if (random == 1) 
				{
					runAway = true;
					print ("Run away!");
				}
			}
		}
		else
			MovingPhase(targetPlayer, -fastMovementSpeed);

		//------Moves Towards the Player-------------
		if (targetDistance < attackDistance)
		{
			if (playerTouch == false && runAway == false && objectTouch == false && enemyTouch == false)
			{
				print ("PlayerNav");
				MovingPhase(targetPlayer, normalMovementSpeed);
			}
		}
		//-------Enemy Moves Around Obstacle-----------
		if (obstacleNav)
		{
			print ("ObstacleNav");
			MovingPhase (targetObject, normalMovementSpeed + 2);
		}
		else if (enemyNav) 
		{
			print ("EnemyNav");
			MovingPhase (targetObject, normalMovementSpeed + 2);
		}
	}

	void MovingPhase(Transform target, float movingSpeed)
	{ 
		print (target);
		if (target.position.y > transform.position.y) 
		{
			transform.position += transform.up * movingSpeed * Time.deltaTime;
			movingUp = true;
		} 
		else if (target.position.y < transform.position.y) 
		{
			transform.position += transform.up * -movingSpeed * Time.deltaTime;
			movingUp = false;
		} 
		else
		{
			transform.position += transform.up * 0;
		}

		if (target.position.x > transform.position.x)
		{
			transform.position += transform.right * movingSpeed * Time.deltaTime;
			movingRight = true;
		}
		else if (target.position.x < transform.position.x)
		{
			transform.position += transform.right * -movingSpeed * Time.deltaTime;
			movingRight = false;
		}
		else
		{
			transform.position += transform.right * 0;
		}
	}

	void OnCollisionEnter2D (Collision2D playerC)
	{
		if (playerC.gameObject.tag == "Player")
		{
			playerTouch = true;
		} 
		else if (playerC.gameObject.tag == "Object") 
		{
			print ("entered");
			objectTouch = true;
			targetObject = CreateVectorPoints(playerC.collider);
		}
		else if (playerC.gameObject.tag == "Enemy")
		{
			enemyTouch = true;
			_enemy = playerC.gameObject;

			if (_enemy.GetComponent<AiIntermediate> ().movingUp || _enemy.GetComponent<AiIntermediate> ().playerTouch)
			{
				print ("he's going up!");

				targetRayCast.transform.InverseTransformPoint(new Vector3 (-1, 0, 0));
				hit = Physics2D.Raycast (targetRayCast.transform.position, -Vector2.right, 2); //check if left is open
				if (hit.collider == null)
				{
					print ("move to the left!");
					targetObject.position = new Vector3 ((_ownCollider.bounds.min.x - 3), _ownCollider.bounds.min.y, 0);
					objectTouch = false;
				}
				else
				{
					targetRayCast.transform.InverseTransformPoint( new Vector3 (1, 0, 0));
					hit = Physics2D.Raycast (targetRayCast.transform.position, Vector2.right, 2); //check if right is open
					if (hit.collider == null)
					{
						print ("move to the right!");
						targetObject.position = new Vector3 ((_ownCollider.bounds.min.x + 3), _ownCollider.bounds.min.y, 0);
						objectTouch = false;
					}
					else
					{
						targetRayCast.transform.InverseTransformPoint(new Vector3 (0, 2, 0));
						hit = Physics2D.Raycast (targetRayCast.transform.position, Vector2.up, 2); //check if up is open
						if (hit.collider == null)
						{
							print ("move to the up!");
							targetObject.position = new Vector3 (_ownCollider.bounds.min.x, (_ownCollider.bounds.min.y + 3), 0);
							objectTouch = false;
						}
						else
						{
							targetRayCast.transform.InverseTransformPoint(new Vector3 (0, -2, 0));
							hit = Physics2D.Raycast (targetRayCast.transform.position, -Vector2.up, 2); //check if down is open
							if (hit.collider == null)
							{
								print ("move to the down!");
								targetObject.position = new Vector3 (_ownCollider.bounds.min.x, (_ownCollider.bounds.min.y - 3), 0);
								objectTouch = false;
							}
							else
								print ("HELP I'M TRAPPED!");
						}
					}
				}

			}
			else
				enemyTouch = false;
		}
	 }
	void OnCollisionStay2D(Collision2D playerC)
	{
		if (playerTouch) 
		{
			_player = playerC.gameObject;
			if (attackTimer < 1) 
			{
				_player.GetComponent<PlayerReceivesDamage> ().meleeHits++;
				attackTimer = permentTimer;
			}
		} 
		//-----Move Around Obstacles-----
		else if (objectTouch) 
		{
			obstacleNav = true;
		}
		else if (enemyTouch)
		{
			obstacleNav = false;
			enemyNav = true;
		}
	}

	void OnCollisionExit2D (Collision2D playerC)
	{
		if (playerC.gameObject.tag == "Player")
		{
			playerTouch = false;
		} 
		else if (playerC.gameObject.tag == "Object") 
		{
			print ("left!");
			objectTouch = false;
			obstacleNav = false;
		}
	}

	void OnTriggerEnter2D (Collider2D _point)
	{
		if (_point.tag == "Point")
		{
			print ("you got there!");
			enemyNav = false;
			enemyTouch = false;
		}
	}
	Transform CreateVectorPoints (Collider2D _collider)
	{
		//---------Finding the 8 Points------
		vectorPoint1 = new Vector3 (_collider.bounds.max.x,
		                            _collider.bounds.max.y  + (transform.lossyScale.y * 2), 0);
		
		vectorPoint2 = new Vector3 (_collider.bounds.max.x + (transform.lossyScale.x * 2),
		                            _collider.bounds.max.y, 0);
		
		vectorPoint3 = new Vector3 (_collider.bounds.max.x + (transform.lossyScale.x * 2),
		                            _collider.bounds.min.y, 0);
		
		vectorPoint4 = new Vector3 (_collider.bounds.max.x,
		                            _collider.bounds.min.y  - (transform.lossyScale.y * 2), 0);
		
		vectorPoint5 = new Vector3 (_collider.bounds.min.x,
		                            _collider.bounds.min.y  - (transform.lossyScale.y * 2), 0);
		
		vectorPoint6 = new Vector3 (_collider.bounds.min.x - (transform.lossyScale.x * 2),
		                            _collider.bounds.min.y, 0);
		
		vectorPoint7 = new Vector3 (_collider.bounds.min.x -(transform.lossyScale.x * 2),
		                            _collider.bounds.max.y, 0);
		
		vectorPoint8 = new Vector3 (_collider.bounds.min.x,
		                            _collider.bounds.max.y  + (transform.lossyScale.y * 2), 0);
		
		
		if (_collider.bounds.max.x <= _ownCollider.bounds.min.x) //on the right side
		{
			if (movingUp)
				targetObject.position = vectorPoint1;
			else //moving down
				targetObject.position = vectorPoint4;
		}
		else if (_collider.bounds.min.x > _ownCollider.bounds.max.x) //on the left side
		{
			if (movingUp)
				targetObject.position = vectorPoint8;
			else //moving down
				targetObject.position = vectorPoint5;
		}
		else if (_collider.bounds.min.y > _ownCollider.bounds.max.y) //on the bottom
		{
			if (movingRight)
				targetObject.position = vectorPoint3;
			else //moving left
				targetObject.position = vectorPoint6;
		}
		else if (_collider.bounds.max.y < _ownCollider.bounds.min.y) //on the top
		{
			if (movingRight)
				targetObject.position = vectorPoint2;
			else //moving left
				targetObject.position = vectorPoint7;
		}

		return targetObject;
	}
}