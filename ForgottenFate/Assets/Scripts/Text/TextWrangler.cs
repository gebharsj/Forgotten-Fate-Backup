using UnityEngine;
using System.Collections;

public class TextWrangler : MonoBehaviour {

	public string wholeText = "";

	private bool georgeTrigger = false;

	public GameObject player;

	public Texture texture; //gets pulled in the Type Writer script
	public Texture Player; //the main player sprite doesn't change
	public Texture NPC;

	public static int	textNum	=	0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		georgeTrigger = GameObject.Find("NPC_George").GetComponent<GeorgeTrigger> ().Trigger;
	
		if (georgeTrigger) //all the character interacting for NPC named "George"
		{
			//textNum = GameObject.Find ("Texter").GetComponent<TypeWriter> (). textNum;
			textNum = TypeWriter.textNum;
			NPC = GameObject.Find("NPC_George").GetComponent<GeorgeTrigger> ().georgeTexture; //gets the Texture from the script dealing with George

			switch (textNum)//the conversation
			{
				case 0:
					wholeText = "What are you doing Kevin?";
					texture = NPC;
					break;
				case 1:
					wholeText = "I'm here to burn your house down!";
					texture = Player;
					break;
				case 2:
					wholeText = "Aww....";
					texture = NPC;
					break;
				case 3:
					wholeText = " ";
					texture = NPC;
					break;
				default: //true for every conversation
					wholeText = "";
					textNum = 0;
					player.GetComponent<PlayerMovement> ().enabled = true;
					texture = null;
					break;
			}
		}

		//-----------------NEXT NPC CONVERSATION-------------------
	}
}
