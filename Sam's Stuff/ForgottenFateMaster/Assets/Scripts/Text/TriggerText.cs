using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerText : MonoBehaviour {

    public GameObject player;
    public GameObject panel;
    public Text text;
    public Button button1;
    public Button button2;
    //public Image face;
    public Sprite[] faceArray;
    public GameObject skills;
    public GameObject playerStatusHUD;

    [HideInInspector]
    public GameObject target;
    string[] temp;
    Sprite[] faceTemp;
    int dialogueLength;
   

    public GameObject[] targetArray;
    public int index = 0;

    //Dialogue Handler variables
    [HideInInspector]
    public string[] dialogue;
    [HideInInspector]
    bool advanceDialogue;
    [HideInInspector]
    public bool useButtons;
    [HideInInspector]
    public int indexForButtons;
  

    void Start()
    {
        indexForButtons = 0;
        useButtons = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (index > targetArray.Length)
            {
                index = 0;
            }
            else if (index <= targetArray.Length)
            {
                GetDialogue();
            }

            advanceDialogue = target.GetComponent<DialogueHandler>().advanceDialogue;

            if (text.GetComponent<ConversationScript>().convoDone == false && Input.GetKeyDown(PlayerPrefs.GetString("Interact")))            //this activates when the player enters the collider and presses e
            {
                PassDialogue();
                BeginConvo();
            }
            else if (text.GetComponent<ConversationScript>().convoDone && (Input.GetKeyDown(PlayerPrefs.GetString("Interact"))))              //this runs when the dialogue is done
            {
                EndConvo();              
            }            
        }        
    }

    void GetDialogue()
    {
        target = targetArray[index];
        dialogue = target.GetComponent<DialogueHandler>().dialogue;
        faceArray = target.GetComponent<DialogueHandler>().faceArray;
        temp = new string[dialogue.Length];
        faceTemp = new Sprite[faceArray.Length];
        print(faceArray.Length);
    }

    void PassDialogue()
    {
        text.GetComponent<ConversationScript>().conversation = dialogue;
        text.GetComponent<ConversationScript>().faceArray = faceArray;
    }

    //Turns off text box, turns on player HUD & spells, enables player movement, resets conversationscript index
    void EndConvo()
    {
        panel.SetActive(false);
        skills.SetActive(true);
        playerStatusHUD.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CombatScript>().enabled = true;
        text.GetComponent<ConversationScript>().convIndex = 0;
        text.GetComponent<ConversationScript>().convoDone = false;
        useButtons = false;
        indexForButtons = 0;
        dialogue = temp;
        faceArray = faceTemp;
        AdvanceDialogue();
    }

    //Turns on text box, turns off player HUD & spells,passes NPC image, and disables player movement
    void BeginConvo()
    {
        target.GetComponent<DialogueHandler>().ButtonHandler();
        panel.SetActive(true);
        skills.SetActive(false);
        playerStatusHUD.SetActive(false);
        //face.sprite = faceArray[0];                                              //this should change to being an index of an array of images so we can have the players face appear when the player talks     
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<CombatScript>().enabled = false;
    }

    void AdvanceDialogue()
    {
        if (advanceDialogue)
        {
            index = index + 1;            
        }        
    }
}