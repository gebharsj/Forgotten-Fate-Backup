using UnityEngine;
using System.Collections;

public class TypeWriter : MonoBehaviour
{
	private const float WAIT_TIME = 0.00001f;

	private float waitTimer = 0.0f;

	public string wholeText = "";
	public string otherText = "";
	private string typewriterText = "";

	private int currentIndex 	= 	0;
	public static int textNum	=	0;

	private bool buttonActivation = false;
	private bool isFinished = false;

	void Start(){
		wholeText = "Still Pulling From TypeWriter";
	}


	void Update ()
	{
		if (Input.GetKeyDown ("e"))
		{ 
			buttonActivation = true;
			isFinished = false;
		}

		if (buttonActivation)
		{
			//if (Input.GetMouseButton (LEFT_MOUSE_BUTTON))
			waitTimer += Time.deltaTime;
			wholeText = GameObject.Find ("Texter").GetComponent<TextWrangler> ().wholeText;
			
			if (waitTimer > WAIT_TIME && currentIndex < wholeText.Length) 
			{            
				typewriterText += wholeText [currentIndex];
				waitTimer = 0.0f;
				++currentIndex;
			}

			if (currentIndex == wholeText.Length)
			{
				buttonActivation = false;
				currentIndex = 0;
				isFinished = true;
				if (wholeText != "")
				{
					textNum++;
					Debug.Log (textNum);
				}

			}
		}
	}
	
	void OnGUI()
	{
		if (isFinished) 
		{
			otherText = typewriterText;
			if (Input.GetKeyDown("e"))
			{
				typewriterText = "";
				buttonActivation = false;
			}
			GUI.TextArea (new Rect (0.0f, 0.0f, Screen.width, Screen.height / 3), otherText);
		}
		else
		{
			GUI.TextArea (new Rect (0.0f, 0.0f, Screen.width, Screen.height / 3), typewriterText);
		}
	}
}