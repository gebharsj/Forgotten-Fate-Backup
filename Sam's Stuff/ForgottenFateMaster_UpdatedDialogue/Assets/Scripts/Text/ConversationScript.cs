using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConversationScript : MonoBehaviour {

    public string[] conversation;    
    public Text textBox;
    public Image face;
    public float writeSpeed = 0.01f;
    public GameObject button1;
    public Text button1TextBox;    
    public GameObject button2;
    public Text button2TextBox;
    public GameObject uselessButton1;
    public Text uselessButton1TextBox;
    public GameObject uselessButton2;
    public Text uselessButton2TextBox;
    public AudioSource sound;
    public bool useNormalButtons;
    public bool useUselessButtons;
    public int indexForButtons;
    public string button1Text;
    public string button2Text;
    public string uselessButton1Text;
    public string uselessButton2Text;
    public Sprite[] faceArray;

    [HideInInspector]
    public int convoIndex = 0;
    [HideInInspector]
    public int maxconvoIndex;
    [HideInInspector]
    public bool convoDone = false;
    [HideInInspector]
    public string text;

    bool textDone = false;
    public bool buttonClicked;

    // Use this for initialization
    void Start () 
	{
        CheckForButtons();
        text = conversation[0];
		face.sprite = faceArray [0];
        StartCoroutine(TypeWriter());        
    }
	
	// Update is called once per frame
	void Update () {
        maxconvoIndex = conversation.Length;

        if (convoIndex == maxconvoIndex)
        {
            convoDone = true;
            convoIndex = 0;
        }

        if (!button1.activeSelf && !button2.activeSelf && !uselessButton1.activeSelf && !uselessButton2.activeSelf)
        {
            if (textDone && !convoDone && ((Input.GetKeyDown(PlayerPrefs.GetString("Interact"))) || convoIndex == 0))
            {
                ConvoHandler();                
            }
        }
        else if(!uselessButton1.activeSelf && !uselessButton2.activeSelf)
        {
            if (textDone && !convoDone && (button1.GetComponent<ButtonHandler>().buttonClicked || button2.GetComponent<ButtonHandler>().buttonClicked))
            {
                ConvoHandler();

                if (button1.GetComponent<ButtonHandler>().buttonClicked)
                {
                    convoIndex = button1.GetComponent<ButtonHandler>().skipToIndex;
                    convoIndex--;
                }                

                ResetButtons();
            }
        }
        else if (!button1.activeSelf && !button2.activeSelf)
        {
            if (textDone && !convoDone && (uselessButton1.GetComponent<ButtonHandler>().buttonClicked || uselessButton2.GetComponent<ButtonHandler>().buttonClicked))
            {
                ConvoHandler();
                ResetButtons();
            }
        }
    }

    IEnumerator TypeWriter()
    {        
        for (int i = 0; i <= text.Length; i++ )
        {
            textBox.text = text.Substring(0, i);
			sound.Play ();
            yield return new WaitForSeconds(PlayerPrefs.GetFloat("WriteSpeed"));
        }
        convoIndex++;
        textDone = true;       
    }

    void CheckForButtons()
    {
        if (useNormalButtons && indexForButtons == convoIndex && !useUselessButtons)
        {
            button1TextBox.text = button1Text;
            button2TextBox.text = button2Text;
            button1.SetActive(true);
            button2.SetActive(true);
            uselessButton1.SetActive(false);
            uselessButton2.SetActive(false);
            useNormalButtons = false;
            useUselessButtons = false;
        }
        else if (useUselessButtons)
        {
            uselessButton1TextBox.text = uselessButton1Text;
            uselessButton2TextBox.text = uselessButton2Text;
            button1.SetActive(false);
            button2.SetActive(false);
            uselessButton1.SetActive(true);
            uselessButton2.SetActive(true);
            useNormalButtons = false;
            useUselessButtons = false;
        }
        else
        {
            button1.SetActive(false);
            button2.SetActive(false);
            uselessButton1.SetActive(false);
            uselessButton2.SetActive(false);
        }
    }

    void ResetButtons()
    {
        button1.GetComponent<ButtonHandler>().buttonClicked = false;
        button2.GetComponent<ButtonHandler>().buttonClicked = false;
        uselessButton1.GetComponent<ButtonHandler>().buttonClicked = false;
        uselessButton2.GetComponent<ButtonHandler>().buttonClicked = false;
    }

    void ConvoHandler()
    {
        CheckForButtons();
        text = conversation[convoIndex];
        face.sprite = faceArray[convoIndex];
        if (faceArray[convoIndex] == null)
        {
            face.enabled = false;
        }
        else
        {
            face.enabled = true;
        }
        textDone = false;
        StartCoroutine(TypeWriter());
    }
}