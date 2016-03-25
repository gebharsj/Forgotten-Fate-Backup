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
    public AudioSource sound;
    public bool useButtons;
    public int indexForButtons;
    public string button1Text;
    public string button2Text;
    public Sprite[] faceArray;

    [HideInInspector]
    public int convIndex = 0;
    [HideInInspector]
    public int maxConvIndex;
    [HideInInspector]
    public bool convoDone = false;
    [HideInInspector]
    public string text;

    bool textDone = false;
    public bool buttonClicked;

    // Use this for initialization
    void Start () 
	{
        indexForButtons = 0;
        text = conversation[0];
		face.sprite = faceArray [0];
        StartCoroutine(TypeWriter());
        CheckForButtons();
    }
	
	// Update is called once per frame
	void Update () {
		print (convIndex);
        maxConvIndex = conversation.Length;

        if (convIndex == maxConvIndex)
        {
            convoDone = true;
            convIndex = 0;
        }        

        if (!button1.activeSelf && !button2.activeSelf)
        {
            if (textDone && !convoDone && ((Input.GetKeyDown(PlayerPrefs.GetString("Interact"))) || convIndex == 0))
            {				
				//--Can Be A Method--
                CheckForButtons();
                text = conversation[convIndex];
                face.sprite = faceArray[convIndex];
                if (faceArray[convIndex] == null)
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
        else
        {
            if (textDone && !convoDone && (button1.GetComponent<ButtonHandler>().buttonClicked || button2.GetComponent<ButtonHandler>().buttonClicked))
            {
                CheckForButtons();
                text = conversation[convIndex];
                face.sprite = faceArray[convIndex];
                if (faceArray[convIndex] == null)
                {
					face.enabled = false;
                }
				else 
				{
					face.enabled = true;
				}
                textDone = false;
                StartCoroutine(TypeWriter());

                

                if (button1.GetComponent<ButtonHandler>().buttonClicked)
                {
                    convIndex = button1.GetComponent<ButtonHandler>().skipToIndex;
                    convIndex--;
                }

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
        convIndex++;
        textDone = true;       
    }

    void CheckForButtons()
    {
        if (useButtons && indexForButtons == convIndex)
        {
            button1TextBox.text = button1Text;
            button2TextBox.text = button2Text;
            button1.SetActive(true);
            button2.SetActive(true);
            useButtons = false;
            indexForButtons = -1;
        }
        else
        {
            button1.SetActive(false);
            button2.SetActive(false);
        }
    }

    void ResetButtons()
    {
        button1.GetComponent<ButtonHandler>().buttonClicked = false;
        button2.GetComponent<ButtonHandler>().buttonClicked = false;
    }
}