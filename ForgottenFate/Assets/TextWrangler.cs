using UnityEngine;
using System.Collections;

public class TextWrangler : MonoBehaviour {

	public string wholeText = "";

	public bool georgeTrigger = false;

	public static int	textNum	=	0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		georgeTrigger = GameObject.Find("NPC").GetComponent<TriggerWriting> ().gTrigger;
	
		if (georgeTrigger) {
			//textNum = GameObject.Find ("Texter").GetComponent<TypeWriter> (). textNum;
			textNum = TypeWriter.textNum;

			if (textNum == 0) {
				wholeText = "What are you doing Kevin?";
			} else if (textNum == 1) {
				wholeText = "I'm here to burn your house down!";
			} else if (textNum == 2)
			{
				wholeText = "Aww....";
			}
			else
			{
				wholeText = "";
				textNum = 0;
			}


		}
	}
}
