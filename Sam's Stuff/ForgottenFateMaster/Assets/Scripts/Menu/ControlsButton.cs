using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlsButton : MonoBehaviour {

    public GameObject controlsPanel;
    public GameObject optionsPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ActivateControlsPanel()
    {
        controlsPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
}
