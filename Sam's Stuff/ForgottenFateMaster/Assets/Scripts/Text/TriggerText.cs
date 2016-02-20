using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerText : MonoBehaviour {

    public GameObject player;
    public GameObject canvas;
    public Text text;
    public GameObject target = null;
    [TextArea(2, 5)]
    public string[] dialogue;

    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log(gameObject);
        if (text.GetComponent<ConversationScript>().convoDone == false && Input.GetKeyDown("e"))                                                 //this activates when the player enters the collider and presses e
        {
            text.GetComponent<ConversationScript>().conversation = dialogue;
            canvas.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;            
        }
        else if (text.GetComponent<ConversationScript>().convoDone && (Input.GetKeyDown("e") || (Input.GetMouseButtonDown(0))))      //this runs when the dialogue is done
        {
            //this.gameObject.GetComponent<TriggerText>().enabled = false;
            canvas.SetActive(false);
            text.GetComponent<ConversationScript>().convIndex = 0;
            player.GetComponent<PlayerMovement>().enabled = true;
        } 
    }

    void OnTriggerExit(Collider col)
    {
        if (target != null)
        {
            if (text.GetComponent<ConversationScript>().convoDone)
            {
                target.SetActive(true);
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
