using UnityEngine;
using System.Collections;

public class ActivateSpell : MonoBehaviour {

	public GameObject NPCFinished;
	public int NPCFinishedIndex;
	public GameObject spellPicture;
	public GameObject letter;
	// Use this for initialization
	void Start ()
	{
		spellPicture.SetActive(false);
		letter.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (NPCFinished.GetComponent<TriggerText> ().index == NPCFinishedIndex) 
		{
			spellPicture.SetActive(true);
			letter.SetActive(true);
		}
	
	}
}
