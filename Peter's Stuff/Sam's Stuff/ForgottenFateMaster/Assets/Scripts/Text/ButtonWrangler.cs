using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonWrangler : MonoBehaviour {

    public Text convoScriptText;
    public bool[] useButtons;
    public string[] button1Text;
    public string[] button2Text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonWranglerMethod(int conversationIndex)
    {
        convoScriptText.GetComponent<ConversationScript>().useUselessButtons = useButtons[conversationIndex];
        convoScriptText.GetComponent<ConversationScript>().uselessButton1Text = button1Text[conversationIndex];
        convoScriptText.GetComponent<ConversationScript>().uselessButton2Text = button2Text[conversationIndex];
    }
}
