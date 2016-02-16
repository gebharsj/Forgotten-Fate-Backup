using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueHandler : MonoBehaviour {      //to use, create an empty gameobject, and place this script, and fill in the dialogue, the target text box, and the target child if there is one

    public GameObject target;
    public string[] dialogue;
    bool convoDone = false;

	// Use this for initialization
	void Start () {
        convoDone = GetComponent<ConversationScript>().convoDone;
	}
	
	// Update is called once per frame
	void Update () {
	    if (target != null)
        {
            if(convoDone)
            {
                target.SetActive(true);
            }
        }
	}
}
