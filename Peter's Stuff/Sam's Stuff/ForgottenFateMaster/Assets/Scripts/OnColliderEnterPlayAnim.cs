using UnityEngine;
using System.Collections;

public class OnColliderEnterPlayAnim : MonoBehaviour 
{
	public GameObject go;

void OnTriggerEnter2D ( Collider2D other)
{
		if (other.tag == "Player") 
		{
			go.GetComponent<Animation> ().enabled = true;
			go.GetComponent<Animator> ().enabled = true;
		}
}
}