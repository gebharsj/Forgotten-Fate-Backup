using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LetterBook : MonoBehaviour {

    public GameObject player;
    public GameObject letterBook;
    public GameObject spells;
    public GameObject playerStatusHUD;
    public GameObject characterStats;
    public GameObject toolTip;
    [HideInInspector]
    public bool letterActive;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyUp("i") && !letterBook.activeSelf)
        {
            player.GetComponent<CombatScript>().enabled = false;
            letterBook.SetActive(true);
            spells.SetActive(false);
            playerStatusHUD.SetActive(false);
            characterStats.SetActive(false);
            toolTip.SetActive(false);
            gameObject.GetComponent<PauseGame>().enabled = false;
            Time.timeScale = 0;
        }
        else if ((Input.GetKeyUp("i") || Input.GetKeyUp("escape")) && letterBook.activeSelf && !letterActive)
        {
            player.GetComponent<CombatScript>().enabled = true;
            letterBook.SetActive(false);
            spells.SetActive(true);
            playerStatusHUD.SetActive(true);
            characterStats.SetActive(true);
            gameObject.GetComponent<PauseGame>().enabled = true;
            Time.timeScale = 1;
        }
	}
}
