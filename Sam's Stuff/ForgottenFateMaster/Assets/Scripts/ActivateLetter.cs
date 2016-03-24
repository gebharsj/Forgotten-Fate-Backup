﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivateLetter : MonoBehaviour {

    public GameObject letter;
    public AudioSource letterSource;
    public AudioClip pageSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(letter.activeSelf && Input.GetKeyUp("escape"))
        {
            letterSource.PlayOneShot(pageSound);
            letter.SetActive(false);
        }
	}

    public void ActivateLetterImage()
    {
        letterSource.PlayOneShot(pageSound);
        letter.SetActive(true);
    }
}
