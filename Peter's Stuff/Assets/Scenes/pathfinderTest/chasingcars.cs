using UnityEngine;
using System.Collections;

public class chasingcars : MonoBehaviour {
	
	public Transform goal;
	private Quaternion rotation = new Quaternion(0,0,0,0);

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		gameObject.transform.rotation = rotation;
		agent.destination = goal.position;
	}
}
