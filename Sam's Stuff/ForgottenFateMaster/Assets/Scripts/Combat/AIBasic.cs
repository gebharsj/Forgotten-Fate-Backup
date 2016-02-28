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
		}
	}

	void MovingPhase()
	{
		if (isNotTouching) 
		{
			if (fpsTarget.position.y > transform.position.y) 
			{
				transform.position += transform.up * enemyMovementSpeed * Time.deltaTime;
			} 
			else 
			{
				transform.position += transform.up * -enemyMovementSpeed * Time.deltaTime;
			}

			if (fpsTarget.position.x > transform.position.x)
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
		}
	}

	void OnCollisionExit2D (Collision2D playerC)
	{
		isNotTouching = true;
	}
}