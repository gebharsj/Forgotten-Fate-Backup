using UnityEngine;
using System.Collections;

public class TriggerWriting : MonoBehaviour {
	
	public string wholeText = "";

	public bool gTrigger = false;

	public GameObject Texter;

	public Texture georgeTexture;

	// Use this for initialization
	void Start () {
		Texter.GetComponent<TypeWriter> ().enabled = false;
		//Debug.Log (wholeText);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay (Collider Cube)
	{
		if (Input.GetKeyDown ("e")) {
			Texter.GetComponent<TypeWriter> ().enabled = true;
			gTrigger = true;
			wholeText = "One End";
			Debug.Log (wholeText + "LOL");
		}
	}

	void OnTriggerExit (Collider Cube)
	{
		wholeText = "";
		TypeWriter.textNum = 0;
		gTrigger = false;
		Texter.GetComponent<TypeWriter> ().enabled = false;
	}
}
