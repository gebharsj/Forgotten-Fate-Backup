using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LetterBook : MonoBehaviour {

    public GameObject letterBook;
    public GameObject skills;
    public GameObject playerStatusHUD;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyUp("i") && !letterBook.activeSelf)
        {
            letterBook.SetActive(true);
            skills.SetActive(false);
            playerStatusHUD.SetActive(false);
            gameObject.GetComponent<PauseGame>().enabled = false;
            Time.timeScale = 0;
        }
        else if(Input.GetKeyUp("i") && letterBook.activeSelf)
        {
            letterBook.SetActive(false);
            skills.SetActive(true);
            playerStatusHUD.SetActive(true);
            gameObject.GetComponent<PauseGame>().enabled = true;
            Time.timeScale = 1;
        }
	}
}
