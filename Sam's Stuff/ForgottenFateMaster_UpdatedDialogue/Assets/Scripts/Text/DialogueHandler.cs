using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueHandler : MonoBehaviour {      //to use, create an empty gameobject, and place this script, and fill in the dialogue          *MAKE SURE TO ADD GAMEOBJECT TO THE CORRECT TARGET ARRAY*

    public Button button1;
    public Button button2;
    public Text convoScriptText;
    [TextArea (2, 5)]
    public string[] dialogue;
    public Sprite[] faceArray;
    public bool advanceDialogue = false;
    public bool useButtons;
    public string[] button1Text;
    public string[] button2Text;
    public int[] indexForButtons;
    public int[] button1SkipToIndex;
    public int[] button2SkipToIndex;

	

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ButtonHandler(int index)
    {
        button1.GetComponent<ButtonHandler>().skipToIndex = button1SkipToIndex[index];
		button2.GetComponent<ButtonHandler>().skipToIndex = button2SkipToIndex[index];
        convoScriptText.GetComponent<ConversationScript>().useButtons = useButtons;
		convoScriptText.GetComponent<ConversationScript>().indexForButtons = indexForButtons[index];
		convoScriptText.GetComponent<ConversationScript>().button1Text = button1Text[index];
		convoScriptText.GetComponent<ConversationScript>().button2Text = button2Text[index];        
    }
}
