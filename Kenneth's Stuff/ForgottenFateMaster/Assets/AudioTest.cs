using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioTest : MonoBehaviour 
{
	float s = 1.0F;
	AudioListener main;
	public Slider audioSlider1; 
	
	void Start()
	{
		main = Camera.main.GetComponent<AudioListener>();
	}
	
	void Update()
	{
		PlayerPrefs.SetFloat ("MusicVolume", audioSlider1.value);
		main.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	}

}
