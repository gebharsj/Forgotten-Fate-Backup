using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerText : MonoBehaviour {

    public GameObject player;
    public GameObject panel;
    public Text text;
    public Button uselessButton1;
    public Button uselessButton2;
    //public Image face;
	[HideInInspector]
    public Sprite[] faceArray;
    public GameObject spells;
    public GameObject playerStatusHUD;

    [HideInInspector]
    public GameObject target;
    string[] temp;
    Sprite[] faceTemp;
    int dialogueLength;
   

    public GameObject[] targetArray;
	//[HideInInspector]
    public int index = 0;

    //Dialogue Handler variables
    [HideInInspector]
    public string[] dialogue;
    [HideInInspector]
    bool advanceDialogue;
    [HideInInspector]
    public bool useButtons; 

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
            else if (index < targetArray.Length)
            {
                GetDialogue();                
            }

            advanceDialogue = target.GetComponent<DialogueHandler>().advanceDialogue;

			if (gameObject.tag == "NPC")
			{
	            if (text.GetComponent<ConversationScript>().convoDone == false && Input.GetKeyDown(PlayerPrefs.GetString("Interact")))            //this activates when the player enters the collider and presses e
	            {
	                PassDialogue();
	                BeginConvo();
	            }
                else if (text.GetComponent<ConversationScript>().convoDone && (Input.GetKeyDown(PlayerPrefs.GetString("Interact")) || (uselessButton1.GetComponent<ButtonHandler>().buttonClicked || uselessButton2.GetComponent<ButtonHandler>().buttonClicked)))              //this runs when the dialogue is done
	            {
					if (text.GetComponent<ConversationScript>().useMoreButtons)
					{
						text.GetComponent<ConversationScript>().convoDone = false;
						LoopConvo();
						PassDialogue();
					}
					else
					{
	               		EndConvo();    
					}
	            }    
			}
			else if (gameObject.tag == "TriggerCutscene")
			{
				if (text.GetComponent<ConversationScript>().convoDone == false )            //this activates when the player enters the collider and presses e
				{
					PassDialogue();
					BeginConvo();
				}
				else if (text.GetComponent<ConversationScript>().convoDone && (Input.GetKeyDown(PlayerPrefs.GetString("Interact"))))              //this runs when the dialogue is done
				{
					EndConvo();  
					gameObject.SetActive(false);
				}     
			}				
        }        
    }

    void GetDialogue()
    {        
		faceArray = new Sprite[dialogue.Length];
        target = targetArray[index];
        dialogue = target.GetComponent<DialogueHandler>().dialogue;
        faceArray = target.GetComponent<DialogueHandler>().faceArray;
        temp = new string[dialogue.Length];
        faceTemp = new Sprite[faceArray.Length];
        if (text.GetComponent<ConversationScript>().convoIndex < dialogue.Length)
        {
            // DON'T FORGET TO PUT BUTTON WRANGLER ON THE NPC CHILD OBJECT
            target.GetComponent<ButtonWrangler>().ButtonWranglerMethod(text.GetComponent<ConversationScript>().convoIndex);
        }        
        target.GetComponent<DialogueHandler>().ButtonHandler();
    }

    void PassDialogue()
    {
        text.GetComponent<ConversationScript>().conversation = dialogue;
        text.GetComponent<ConversationScript>().faceArray = faceArray;
    }

	void BeginConvo()
	{
		panel.SetActive(true);
		spells.SetActive(false);
		playerStatusHUD.SetActive(false);   
		player.GetComponent<PlayerMovement>().enabled = false;
		player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		player.GetComponent<CombatScript>().enabled = false;
	}

    //Turns off text box, turns on player HUD & spells, enables player movement, resets conversationscript index
    void EndConvo()
	{
		print ("normal exit");
		panel.SetActive (false);
		spells.SetActive (true);
		playerStatusHUD.SetActive (true);
		player.GetComponent<PlayerMovement> ().enabled = true;
		player.GetComponent<CombatScript> ().enabled = true;
		text.GetComponent<ConversationScript> ().convoIndex = 0;
		text.GetComponent<ConversationScript> ().convoDone = false;
		dialogue = temp;
		faceArray = faceTemp;
		AdvanceDialogue ();
    }

	void LoopConvo()
	{
		print ("FAST LOOP");
		text.GetComponent<ConversationScript> ().convoIndex = 0;
		index++;  
	}

    //Turns on text box, turns off player HUD & spells,passes NPC image, and disables player movement
 
    void AdvanceDialogue()
    {
        if (advanceDialogue)
        {
            index = index + 1;            
        }        
    }
}