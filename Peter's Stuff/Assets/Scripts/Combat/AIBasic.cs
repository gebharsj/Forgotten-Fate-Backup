using UnityEngine;
using System.Collections;

public class AIBasic : MonoBehaviour {

	public float fpsTargetDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public Transform fpsTarget;

	bool	isNotTouching = true;

	// Use this for initialization
	void Start ()
	{

	}
	// Update is called once per frame
	void Update ()
	{
		fpsTargetDistance = Vector3.Distance (fpsTarget.position, transform.position);

		if (fpsTargetDistance < attackDistance)
		{
			MovingPhase();
			Debug.Log ("ATTACK!");
		}
	}

	void MovingPhase()
	{
		if (isNotTouching) 
		{
			if (fpsTarget.position.y > transform.position.y) 
			{
				transform.position += transform.up * enemyMovementSpeed * Time.deltaTime;
				Debug.Log ("We;re going up!");
			} 
			else 
			{
				transform.position += transform.up * -enemyMovementSpeed * Time.deltaTime;
				Debug.Log ("We;re going down!");
			}



			if (fpsTarget.position.x > transform.position.x)
			{
				transform.position += transform.right * enemyMovementSpeed * Time.deltaTime;
				Debug.Log ("We;re going right!!");
			}
			else 
			{
				transform.position += transform.right * -enemyMovementSpeed * Time.deltaTime;
				Debug.Log ("We;re going left!");
			}
		}

	}

	void OnCollisionStay(Collision playerC)
	{
		if (playerC.gameObject.tag == "Player") 
		{
			isNotTouching = false;
			Debug.Log ("HEHE they're touching");
		}
	}

	void OnCollisionExit (Collision playerC)
	{
		isNotTouching = true;
	}


}
