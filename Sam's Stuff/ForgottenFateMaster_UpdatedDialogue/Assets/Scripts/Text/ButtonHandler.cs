using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandler : MonoBehaviour {

    public Text convoText;
    public Text buttonTextBox;
    public int skipToIndex;
    public bool buttonClicked;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTargetIndex()
    {
        if (skipToIndex == 0)
        {
            buttonClicked = true;
        }
        else
        {
            convoText.GetComponent<ConversationScript>().convIndex = skipToIndex--;
            buttonClicked = true;
        }
    }
}
