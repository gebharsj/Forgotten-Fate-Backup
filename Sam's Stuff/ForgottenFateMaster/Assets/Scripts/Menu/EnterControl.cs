using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterControl : MonoBehaviour {

    public Text fieldText;
    public InputField inputField;
    public string controlName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void SetControl(InputField input)
    {   
        PlayerPrefs.SetString(controlName, input.text);
        fieldText.text = PlayerPrefs.GetString(controlName);                 
    }
}