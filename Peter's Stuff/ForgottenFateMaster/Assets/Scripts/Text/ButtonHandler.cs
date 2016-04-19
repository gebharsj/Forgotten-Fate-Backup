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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print (buttonClicked + "buttonClicked");
    }

    public void ChangeTargetIndex()
    {
        convoText.GetComponent<ConversationScript>().convoIndex = targetIndex;

        if (convoText.GetComponent<ConversationScript>().textDone)
        {
            //print (convoText.GetComponent<ConversationScript> ().textDone + " clicked");
            buttonClicked = true;
        }
        else
        {
            //print (convoText.GetComponent<ConversationScript> ().textDone + " not clicked");
            buttonClicked = false;
        }
    }

    public void ButtonClicked()
    {
        if (convoText.GetComponent<ConversationScript>().textDone)
        {
            //print (convoText.GetComponent<ConversationScript> ().textDone + " clicked");
            buttonClicked = true;
        }
        else
        {
            //print (convoText.GetComponent<ConversationScript> ().textDone + " not clicked");
            buttonClicked = false;
        }
    }
}