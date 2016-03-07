using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerText : MonoBehaviour {

    public GameObject player;
    public GameObject panel;
    public Text text;
    public Image face;
    public Sprite NPCImage;
    public GameObject skills;
    public GameObject playerStatusHUD;

    [HideInInspector]
    public GameObject target;    
    [HideInInspector]
    public string[] dialogue;
    string[] temp;
    int dialogueLength;
    bool advanceDialogue;

    public GameObject[] targetArray;
    public int index = 0;

    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        advanceDialogue = target.GetComponent<DialogueHandler>().advanceDialogue;

        if (index >= targetArray.Length)
        {
            panel.SetActive(false);
        }
        else
        {
            if (ConversationScript.convoDone == false && Input.GetKeyDown("e") )            //this activates when the player enters the collider and presses e
            {
                skills.SetActive(false);
                playerStatusHUD.SetActive(false);
                face.sprite = NPCImage;
                ConversationScript.conversation = dialogue;
                panel.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
            else if (ConversationScript.convoDone && (Input.GetKeyDown("e")) )              //this runs when the dialogue is done
            {
                panel.SetActive(false);
                ConversationScript.convIndex = 0;
                skills.SetActive(true);
                playerStatusHUD.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (index >= targetArray.Length)
        {
            index = 0;
        }

        if (index <= targetArray.Length)
        {
            target = targetArray[index];
            dialogue = target.GetComponent<DialogueHandler>().dialogue;
            temp = new string[dialogue.Length];
        }        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (advanceDialogue)
        {
            index = index + 1;
            dialogue = temp;
            ConversationScript.convoDone = false;
        }
        else
        {
            ConversationScript.convoDone = false;
        }
    }
}
