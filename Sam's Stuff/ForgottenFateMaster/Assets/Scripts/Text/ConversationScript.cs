﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConversationScript : MonoBehaviour {

    //[HideInInspector]
    public static string[] conversation;
    [HideInInspector]
    public string text;
    public Text textBox;
    public float writeSpeed = 0.01f;
    [HideInInspector]
    bool textDone = false;
    [HideInInspector]
    public int convIndex = 0;
    public int maxConvIndex;
    [HideInInspector]
    public static bool convoDone = false;
    public AudioSource sound;

    // Use this for initialization
    void Start () {
        
        text = conversation[0];
        StartCoroutine(TypeWriter());
    }
	
	// Update is called once per frame
	void Update () {
        maxConvIndex = conversation.Length;
        if (textDone && convIndex != maxConvIndex && ((Input.GetKeyDown("e")) || (Input.GetMouseButtonDown(0))))
        {
            text = conversation[convIndex];            
            textDone = false;
            StartCoroutine(TypeWriter());
        }

        if(convIndex == maxConvIndex)
        {
            convoDone = true;
            convIndex = 0;            
        }
    }

    IEnumerator TypeWriter()
    {
        for (int i = 0; i <= text.Length; i++ )
        {
            textBox.text = text.Substring(0, i);
            sound.Play();
            yield return new WaitForSeconds(writeSpeed);
        }
        convIndex++;
        textDone = true;       
    }
}
