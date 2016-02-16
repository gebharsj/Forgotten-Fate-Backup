using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConversationScript : MonoBehaviour {

    public string[] conversation;
    [HideInInspector]
    public string text;
    public Text textBox;
    public float writeSpeed = 0.01f;
    bool textDone = false;
    [HideInInspector]
    public int convIndex = 0;
    int maxConvIndex;
    [HideInInspector]
    public bool convoDone = false;

    // Use this for initialization
    void Start () {
        text = conversation[0];
        maxConvIndex = conversation.Length;
        StartCoroutine(TypeWriter());
    }
	
	// Update is called once per frame
	void Update () {
        if (textDone && convIndex != maxConvIndex && ((Input.GetKeyDown("e")) || (Input.GetMouseButtonDown(0))))
        {
            text = conversation[convIndex];            
            textDone = false;
            StartCoroutine(TypeWriter());
        }
        if(convIndex == maxConvIndex)
        {
            convoDone = true;
        }
    }

    IEnumerator TypeWriter()
    {
        for (int i = 0; i <= text.Length; i++ )
        {
            textBox.text = text.Substring(0, i);
            yield return new WaitForSeconds(writeSpeed);
        }
        convIndex++;
        textDone = true;       
    }
}
