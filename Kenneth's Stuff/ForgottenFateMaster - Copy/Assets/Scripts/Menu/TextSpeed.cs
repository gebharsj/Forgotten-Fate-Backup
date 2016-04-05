using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextSpeed : MonoBehaviour {

	public Slider textSlider1;
	float s = 0.1F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerPrefs.SetFloat ("WriteSpeed", textSlider1.value);
	}
}
