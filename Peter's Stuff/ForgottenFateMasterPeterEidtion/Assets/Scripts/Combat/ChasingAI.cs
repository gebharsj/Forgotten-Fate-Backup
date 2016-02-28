using UnityEngine;
using System.Collections;

public class ChasingAI : MonoBehaviour {
	
	public Transform goal;
	//public GameObject enemy;
	public Vector3 enemyLocation;
	private Quaternion rotation = new Quaternion(0,0,0,0);

	public bool isNotTouching = true;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		enemyLocation = gameObject.transform.position;
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();

		if (isNotTouching) 
		{
			agent.updateRotation = false;
			gameObject.transform.rotation = rotation;
			agent.destination = goal.position;
		}
		else
		{
			agent.destination = enemyLocation;
			//---ATTACK SCRIPT------
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
