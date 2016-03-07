using UnityEngine;
using System.Collections;

public class UISounds : MonoBehaviour {

	public AudioSource sound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			sound.Play ();
		}
	}
}
