using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetControls : MonoBehaviour {

    public InputField interactField;
    public InputField upField;
    public InputField leftField;
    public InputField downField;
    public InputField rightField;
    public InputField switchWeapField;
    public InputField spell1;
    public InputField spell2;
    public InputField spell3;
    public InputField spell4;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetToDefault()
    {
        PlayerPrefs.SetString("Interact", "e");
        PlayerPrefs.SetString("MoveUp", "w");
        PlayerPrefs.SetString("MoveLeft", "a");
        PlayerPrefs.SetString("MoveDown", "s");
        PlayerPrefs.SetString("MoveRight", "d");
        PlayerPrefs.SetString("SwitchWeap", "q");
        PlayerPrefs.SetString("Spell1", "1");
        PlayerPrefs.SetString("Spell2", "2");
        PlayerPrefs.SetString("Spell3", "3");
        PlayerPrefs.SetString("Spell4", "4");

        interactField.text = PlayerPrefs.GetString("Interact");
        upField.text = PlayerPrefs.GetString("MoveUp");
        leftField.text = PlayerPrefs.GetString("MoveLeft");
        downField.text = PlayerPrefs.GetString("MoveDown");
        rightField.text = PlayerPrefs.GetString("MoveRight");
        switchWeapField.text = PlayerPrefs.GetString("SwitchWeap");
        spell1.text = PlayerPrefs.GetString("Spell1");
        spell2.text = PlayerPrefs.GetString("Spell2");
        spell3.text = PlayerPrefs.GetString("Spell3");
        spell4.text = PlayerPrefs.GetString("Spell4");
    }
}
