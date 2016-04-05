using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivateLetter : MonoBehaviour {

    public GameObject letter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(letter.activeSelf && Input.GetKeyUp("escape"))
        {
            letter.SetActive(false);
        }
	}

    public void ActivateLetterImage()
    {
        letter.SetActive(true);
    }
}
