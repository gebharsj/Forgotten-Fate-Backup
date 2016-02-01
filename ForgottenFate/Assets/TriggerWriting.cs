using UnityEngine;
using System.Collections;

public class TriggerWriting : MonoBehaviour {
	
	public string wholeText = "This is a simple text. Is this fast enough for you Sam?";



	// Use this for initialization
	void Start () {
		wholeText = "This is a simple text. Is this fast enough for you Sam?";
		Debug.Log (wholeText);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider Cube)
	{
		Debug.Log ("Cheese!");
		wholeText = "Hello World!";
		Debug.Log (wholeText + "LOL");
	}
}
