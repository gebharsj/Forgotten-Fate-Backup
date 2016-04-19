using UnityEngine;
using System.Collections;

public class ControlInitialization : MonoBehaviour {

    // Use this for initialization
    void Start () {
        if(PlayerPrefs.GetString("Interact") == "")
        {
            PlayerPrefs.SetString("Interact", "e");
        }
        if (PlayerPrefs.GetString("MoveUp") == "")
        {
            PlayerPrefs.SetString("MoveUp", "w");
        }
        if (PlayerPrefs.GetString("MoveLeft") == "")
        {
            PlayerPrefs.SetString("MoveLeft", "a");
        }
        if (PlayerPrefs.GetString("MoveDown") == "")
        {
            PlayerPrefs.SetString("MoveDown", "s");
        }
        if (PlayerPrefs.GetString("MoveRight") == "")
        {
            PlayerPrefs.SetString("MoveRight", "d");
        }
        if (PlayerPrefs.GetString("SwitchWeap") == "")
        {
            PlayerPrefs.SetString("SwitchWeap", "q");
        }
        if (PlayerPrefs.GetString("Spell1") == "")
        {
            PlayerPrefs.SetString("Spell1", "1");
        }
        if (PlayerPrefs.GetString("Spell2") == "")
        {
            PlayerPrefs.SetString("Spell2", "2");
        }
        if (PlayerPrefs.GetString("Spell3") == "")
        {
            PlayerPrefs.SetString("Spell3", "3");
        }
        if (PlayerPrefs.GetString("Spell4") == "")
        {
            PlayerPrefs.SetString("Spell4", "4");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
