using UnityEngine;
using System.Collections;

public class TriggerWriting : MonoBehaviour {
	
	public string wholeText = "This is a simple text. Is this fast enough for you Sam? ";

	public bool gTrigger = false;




	// Use this for initialization
	void Start () {
		wholeText = "This is a simple text. Is this fast enough for you Sam?";
		//Debug.Log (wholeText);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay (Collider Cube)
	{
		gTrigger = true;
		wholeText = "One End";
		Debug.Log (wholeText + "LOL");
	}

	void OnTriggerExit (Collider Cube)
	{
		wholeText = "";
		TypeWriter.textNum = 0;
	}
}
