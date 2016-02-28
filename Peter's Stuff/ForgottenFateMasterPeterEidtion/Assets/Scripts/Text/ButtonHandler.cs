using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandler : MonoBehaviour {

    public Text buttonTextBox;
    public int targetIndex;
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
        Debug.Log("target index " + targetIndex);
        ConversationScript.convIndex = targetIndex;
        buttonClicked = true;
    }
}
