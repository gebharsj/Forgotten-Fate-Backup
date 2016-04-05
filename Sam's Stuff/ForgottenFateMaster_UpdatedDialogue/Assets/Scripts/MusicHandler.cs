using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

    public AudioSource musicSource;

    public AudioClip townSong;
    public AudioClip environmentSong;

	// Use this for initialization
	void Start () {
        musicSource.clip = townSong;
        musicSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Triggered");
        if (col.tag == "Player")
        {
            Debug.Log("Triggered");
            if (musicSource.clip == townSong)
            {
                musicSource.clip = environmentSong;
                musicSource.Play();
            }
            else if (musicSource.clip == environmentSong)
            {
                musicSource.clip = townSong;
                musicSource.Play();
            }
        }
    }
}
