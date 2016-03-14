using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetControls : MonoBehaviour {

    public InputField interactField;
    public InputField upField;
    public InputField leftField;
    public InputField downField;
    public InputField rightField;

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

        interactField.text = PlayerPrefs.GetString("Interact");
        upField.text = PlayerPrefs.GetString("MoveUp");
        leftField.text = PlayerPrefs.GetString("MoveLeft");
        downField.text = PlayerPrefs.GetString("MoveDown");
        rightField.text = PlayerPrefs.GetString("MoveRight");
    }
}
