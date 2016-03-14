using UnityEngine;
using System.Collections;

public class UnderstandingRayCast : MonoBehaviour {

	public RaycastHit2D hit;
	public BoxCollider2D _collider;
	public float 	_cheese = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if (Physics2D.Raycast (transform.position, Vector2.right, 3.0f)) {
			//print ("There's something to the right of this object.");
		//}
		hit = Physics2D.Raycast (_collider.bounds.min, -Vector2.right, _cheese);
		print (hit.collider.tag);
		print (hit.transform);
	}
}
