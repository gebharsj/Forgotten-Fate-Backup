using UnityEngine;
using System.Collections;

public class UnderstandingBounds : MonoBehaviour {

	public Bounds _bounds;
	public Transform _transform;
	public BoxCollider2D _collider;
	public GameObject _thing;
	public Vector3 _vector;

	public float height;
	public float width;

	// Use this for initialization
	void Start () {
		_vector = new Vector3(-.2f, -.2f, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//----------Understanding Bounds---------
		_bounds = _collider.bounds;
		print (_bounds + " normal bounds");
		print (_bounds.max + "max bounds");
		print (_bounds.min + "min bounds");
		//---------Addition and Subtraction with Bounds-----------
		_transform.transform.position = (_collider.bounds.min) - _vector;
		print (_thing.transform.position + " transform position");
		//-----------Collider Size-------
		print (_collider.size + " size");
		//---------Height and Width--------
		height = _collider.size.y;
		width = _collider.size.x;
		print (height + " height of collider");
		print (width + " width of collider");
		//---------Adding Width to Bounds-------
		_vector = new Vector3 (width, 0, 0);
		_transform.transform.position = (_collider.bounds.min) - _vector;
		print (_thing.transform.position + " transform position with width");


		//_transform.transform.position = (_collider.bounds.min) - _collider.size;
		//print (_thing.transform.position + " transform position with size change");

	}
}
