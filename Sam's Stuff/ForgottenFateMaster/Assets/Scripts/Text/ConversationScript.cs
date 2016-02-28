using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConversationScript : MonoBehaviour {

    public static string[] conversation;    
    public Text textBox;
    public float writeSpeed = 0.01f;
    public GameObject button1;
    public Text button1TextBox;    
    public GameObject button2;
    public Text button2TextBox;
    public AudioSource sound;
    public static bool useButtons;
    public static int indexForButtons;
    public static string button1Text;
    public static string button2Text;

    [HideInInspector]
    public static int convIndex = 0;
    [HideInInspector]
    public int maxConvIndex;
    [HideInInspector]
    public static bool convoDone = false;
    [HideInInspector]
    public string text;

    bool textDone = false;
    public static bool buttonClicked;

    // Use this for initialization
    void Start () {
        text = conversation[0];        
        StartCoroutine(TypeWriter());
    }
	
	// Update is called once per frame
	void Update () {
        maxConvIndex = conversation.Length;
        Debug.Log(useButtons);
        Debug.Log(convIndex);

        if (textDone && convIndex != maxConvIndex && (Input.GetKeyDown("e") || buttonClicked == true) )
        {            
            text = conversation[convIndex];            
            textDone = false;
            StartCoroutine(TypeWriter());

            if (useButtons && indexForButtons == convIndex)
            {
                button1TextBox.text = button1Text;
                button2TextBox.text = button2Text;
                button1.SetActive(true);
                button2.SetActive(true);
                useButtons = false;
            }
            else
            {
                button1.SetActive(false);
                button2.SetActive(false);
            }

            buttonClicked = false;
            //button1.SetActive(false);
            //button2.SetActive(false);
            //useButtons = false;
        }

        if(convIndex == maxConvIndex)
        {
            convoDone = true;
            convIndex = 0;
        }
    }

    IEnumerator TypeWriter()
    {
        for (int i = 0; i <= text.Length; i++ )
        {
            textBox.text = text.Substring(0, i);
			sound.Play ();
            yield return new WaitForSeconds(writeSpeed);
        }
        convIndex++;
        textDone = true;       
    }
}
