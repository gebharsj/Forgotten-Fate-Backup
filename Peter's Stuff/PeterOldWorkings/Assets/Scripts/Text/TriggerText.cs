using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerText : MonoBehaviour {

    public GameObject player;
    public GameObject canvas;
    public Text text;

    void OnTriggerStay(Collider player)
    {
        if (text.GetComponent<ConversationScript>().convoDone && (Input.GetKeyDown("e") || (Input.GetMouseButtonDown(0))))
        {
            canvas.SetActive(false);
            text.GetComponent<ConversationScript>().convIndex = 0;
            player.GetComponent<PlayerMovement>().enabled = true;
            text.GetComponent<ConversationScript>().convoDone = false;
        }
        else if (Input.GetKeyDown("e"))
        {
            canvas.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;            
        }
    }
}
