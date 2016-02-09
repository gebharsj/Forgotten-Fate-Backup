using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerText : MonoBehaviour {

    public GameObject player;
    public GameObject canvas;
    public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider player)
    {
        if (Input.GetKeyDown("e"))
        {
            canvas.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;

            
        }

        if (text.GetComponent<ConversationScript>().convoDone)
        {
            canvas.SetActive(false);
            text.GetComponent<ConversationScript>().convIndex = 0;
            player.GetComponent<PlayerMovement>().enabled = true;
            text.GetComponent<ConversationScript>().convoDone = false;
        }


    }

    //void OnTriggerExit(Collider player)
    //{
    //    canvas.SetActive(false);
    //    text.GetComponent<ConversationScript>().convIndex = 0;
    //}
}
