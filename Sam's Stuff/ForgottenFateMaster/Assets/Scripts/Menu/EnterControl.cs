using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterControl : MonoBehaviour {

    public Text fieldText;
    public InputField inputField;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetControl(string controlName)
    {
        PlayerPrefs.SetString(controlName, inputField.text);
        fieldText.text = PlayerPrefs.GetString(controlName);
    }
}
