using UnityEngine;
using System.Collections;

public class GeorgeTrigger : MonoBehaviour {
	
	public string wholeText = "";

	public bool Trigger = false; //contains the bool for the character

	public GameObject Texter;

	public Texture georgeTexture; //contains the texture for the character

	// Use this for initialization
	void Start () {
		Texter.GetComponent<TypeWriter> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay (Collider Cube)
	{
		if (Input.GetKeyDown ("e"))
		{
			Texter.GetComponent<TypeWriter> ().enabled = true;
			Trigger = true;
		}
	}

	void OnTriggerExit (Collider Cube)
	{
		wholeText = "";
		TypeWriter.textNum = 0;
		Trigger = false;
		Texter.GetComponent<TypeWriter> ().enabled = false;
	}
}
