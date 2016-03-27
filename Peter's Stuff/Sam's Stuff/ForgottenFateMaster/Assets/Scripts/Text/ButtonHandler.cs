using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandler : MonoBehaviour {

    public Text convoText;
    public int skipToIndex;
	public int speakingLinesIndex;
    public int targetIndex;
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
        convoText.GetComponent<ConversationScript>().convoIndex = targetIndex;
        buttonClicked = true;        
    }

    public void ButtonClicked()
    {
        buttonClicked = true;
    }
}
