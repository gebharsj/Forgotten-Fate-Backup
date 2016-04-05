using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioSlider : MonoBehaviour {

    public Slider volumeSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void SetVolume(string prefName)
    {
        PlayerPrefs.SetFloat(prefName, volumeSlider.value);
    }
}
