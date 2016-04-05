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
	public bool useMoreButtons = false;
    public string button1Text;
    public string button2Text;
    public int indexForButtons;
    public int button1TargetIndex;
	public int button1SpeakingLinesIndex;
    public int button1SkipToIndex;
    public int button2TargetIndex;
	public int button2SpeakingLinesIndex;
    public int button2SkipToIndex;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

    public void ButtonHandler()
    {
        button1.GetComponent<ButtonHandler>().targetIndex = button1TargetIndex;
		button1.GetComponent<ButtonHandler>().speakingLinesIndex = button1SpeakingLinesIndex;
        button1.GetComponent<ButtonHandler>().skipToIndex = button1SkipToIndex;
        button2.GetComponent<ButtonHandler>().targetIndex = button2TargetIndex;
		button2.GetComponent<ButtonHandler>().speakingLinesIndex = button2SpeakingLinesIndex;
        button2.GetComponent<ButtonHandler>().skipToIndex = button2SkipToIndex;
        convoScriptText.GetComponent<ConversationScript>().useNormalButtons = useButtons;
		convoScriptText.GetComponent<ConversationScript>().useMoreButtons = useMoreButtons;
        convoScriptText.GetComponent<ConversationScript>().indexForButtons = indexForButtons;
        convoScriptText.GetComponent<ConversationScript>().button1Text = button1Text;
        convoScriptText.GetComponent<ConversationScript>().button2Text = button2Text;         
    }
}
