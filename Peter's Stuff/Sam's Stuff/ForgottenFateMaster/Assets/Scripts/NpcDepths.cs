//Depth

using UnityEngine;
using System.Collections;

public class NpcDepths : MonoBehaviour 
{
	public float Yposition;
	public float Xposition;
	//public SpriteRenderer tree;
	
	void Update ()
	{
		Xposition = transform.position.x;
		Yposition = transform.position.y;
		transform.position = new Vector3(Xposition, Yposition, 0);
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = (int) (-Yposition);

		
	}
	
	// Update is called once per frame
	
}
