using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueHandler : MonoBehaviour {      //to use, create an empty gameobject, and place this script, and fill in the dialogue          *MAKE SURE TO ADD GAMEOBJECT TO THE CORRECT TARGET ARRAY*
       
    [TextArea (2, 5)]
    public string[] dialogue;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
