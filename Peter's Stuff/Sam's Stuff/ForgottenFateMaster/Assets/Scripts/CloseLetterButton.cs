using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseLetterButton : MonoBehaviour {

    public GameObject letter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CloseLetter()
    {
        letter.SetActive(false);
    }
}
