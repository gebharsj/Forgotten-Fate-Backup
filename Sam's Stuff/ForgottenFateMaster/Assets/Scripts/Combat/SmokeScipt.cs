using UnityEngine;
using System.Collections;

public class SmokeScipt : MonoBehaviour {
	public Transform target;
	public Transform smokePrefab;
	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Rigidbody2D clone;
		clone = Instantiate(smokePrefab, transform.position, transform.rotation) as Rigidbody2D;
		float step = speed * Time.deltaTime; transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
	
	}

