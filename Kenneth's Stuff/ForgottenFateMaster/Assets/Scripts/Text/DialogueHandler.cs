using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueHandler : MonoBehaviour {      //to use, create an empty gameobject, and place this script, and fill in the dialogue          *MAKE SURE TO ADD GAMEOBJECT TO THE CORRECT TARGET ARRAY*
       
    [TextArea (2, 5)]
    public string[] dialogue;
    public bool advanceDialogue = false;
    public bool useButtons;
    public string button1Text;
    public string button2Text;
    public int indexForButtons;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Index " + indexForButtons);
        //Debug.Log("length " + gameObject + dialogue.Length);
        if (useButtons && indexForButtons >= 0 && indexForButtons <= dialogue.Length)
        {
            ConversationScript.useButtons = useButtons;
            ConversationScript.indexForButtons = indexForButtons;
            ConversationScript.button1Text = button1Text;
            ConversationScript.button2Text = button2Text;
        }
	}
}
