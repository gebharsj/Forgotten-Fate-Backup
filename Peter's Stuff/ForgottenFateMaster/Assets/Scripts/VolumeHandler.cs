using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeHandler : MonoBehaviour {

    public AudioSource uISource;
    public AudioSource musicSource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        uISource.volume = PlayerPrefs.GetFloat("UI_Sounds");
        musicSource.volume = PlayerPrefs.GetFloat("Music");
	}
}
