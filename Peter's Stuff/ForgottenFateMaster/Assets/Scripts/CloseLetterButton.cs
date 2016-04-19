using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseLetterButton : MonoBehaviour {

    public GameObject letter;
    public GameObject letterBook;
    public AudioSource letterSource;
    public AudioClip pageSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CloseLetter()
    {
        letterSource.PlayOneShot(pageSound);
        letter.SetActive(false);
        letterBook.GetComponent<LetterBook>().letterActive = false;
    }
}
