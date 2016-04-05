using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerText : MonoBehaviour {

    public GameObject mainCam;
    public GameObject player;
    public GameObject panel;
    public Text text;
    public Image face;
    public Sprite NPCImage;
    public GameObject spells;
    public GameObject playerStatusHUD;
    public GameObject characterStats;

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
        if (col.tag == "Player")
        {
            if (index >= targetArray.Length)
            {
                index = 0;
            }
            else if (index <= targetArray.Length)
            {
                GetDialogue();
            }

            advanceDialogue = target.GetComponent<DialogueHandler>().advanceDialogue;            

            if (ConversationScript.convoDone == false && Input.GetKeyDown(PlayerPrefs.GetString("Interact")))            //this activates when the player enters the collider and presses e
            {
                PassDialogue();
                BeginConvo();
            }
            else if (ConversationScript.convoDone && (Input.GetKeyDown(PlayerPrefs.GetString("Interact"))))              //this runs when the dialogue is done
            {
                EndConvo();              
            }            
        }        
    }

    void GetDialogue()
    {
        target = targetArray[index];
        dialogue = target.GetComponent<DialogueHandler>().dialogue;
        temp = new string[dialogue.Length];
    }

    void PassDialogue()
    {
        ConversationScript.conversation = dialogue;
    }

    //Turns off text box, turns on player HUD & spells, enables player movement, resets conversationscript index
    void EndConvo()
    {
        panel.SetActive(false);
        spells.SetActive(true);
        playerStatusHUD.SetActive(true);
        characterStats.SetActive(true);
        mainCam.GetComponent<LetterBook>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CombatScript>().enabled = true;
        ConversationScript.convIndex = 0;
        ConversationScript.convoDone = false;
        AdvanceDialogue();
    }

    //Turns on text box, turns off player HUD & spells,passes NPC image, and disables player movement
    void BeginConvo()
    {
        panel.SetActive(true);
        spells.SetActive(false);
        playerStatusHUD.SetActive(false);
        characterStats.SetActive(false);
        face.sprite = NPCImage;                                              //this should change to being an index of an array of images so we can have the players face appear when the player talks     
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<CombatScript>().enabled = false;
        mainCam.GetComponent<LetterBook>().enabled = false;
    }

    void AdvanceDialogue()
    {
        if (advanceDialogue)
        {
            index = index + 1;
            dialogue = temp;
        }
    }
}