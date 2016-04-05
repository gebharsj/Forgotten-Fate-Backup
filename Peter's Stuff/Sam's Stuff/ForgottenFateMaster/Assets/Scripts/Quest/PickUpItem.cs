using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour {

	public GameObject keyItem;

	public bool isAquired = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.tag == "Player" && (Input.GetKeyDown (PlayerPrefs.GetString ("Interact"))))
		{
			keyItem.SetActive(false);
			isAquired = true;
		}
	}
}
