//Depth

using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour 
{
	public float Yposition;
	public float Xposition;
	//public SpriteRenderer tree;

	void Start ()
	{
		Xposition = transform.position.x;
		Yposition = transform.position.y;
		transform.position = new Vector3(Xposition, Yposition, 0);
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = (int) (-Yposition + 13);

	}
	
	// Update is called once per frame

}
