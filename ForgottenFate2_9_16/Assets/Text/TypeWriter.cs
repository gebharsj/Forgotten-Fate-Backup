using UnityEngine;
using System.Collections;

public class TypeWriter : MonoBehaviour
{
	private const float WAIT_TIME = 0.00001f;

	private float waitTimer = 0.0f;
	private float delay		=	0.0f;

	public string wholeText = "";
	public string otherText = "";
	private string typewriterText = "";

	private int currentIndex 	= 	0;
	public static int textNum	=	0;

	private bool buttonActivation = false;
	private bool isFinished = false;

	public GameObject player;

	public Texture texture;

	void Start(){
	}

	void Update ()
	{
		if (Input.GetKeyDown ("e"))
		{ 
			buttonActivation = true;
			isFinished = false;
			textNum++;
			Debug.Log (textNum + " Before");
			//---------------Deactivate Movement-------------
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Rigidbody> ().velocity = Vector3.zero;

		}

		if (buttonActivation)
		{
			if (delay < .5)
			{
				delay += Time.deltaTime;
				Debug.Log (delay + ": this is delay");
			}

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
					Debug.Log (textNum + " After");
					//by peter
				}
			}
		}
	}
	
	void OnGUI()
	{
		if (isFinished) 
		{
			otherText = typewriterText;
			texture = GameObject.Find ("Texter").GetComponent<TextWrangler> ().texture;

			if (Input.GetKeyDown("e"))
			{
				typewriterText = "";
				buttonActivation = false;
			}

			GUI.TextArea (new Rect (50, 0.0f, Screen.width, Screen.height / 3), otherText);
			GUI.DrawTexture (new Rect(0, 0, 50, 50), texture, ScaleMode.ScaleAndCrop, true, 10.0F);
		}
		else
		{
			GUI.DrawTexture (new Rect(0, 0, 50, 50), texture, ScaleMode.ScaleAndCrop, true, 10.0F);
			GUI.TextArea (new Rect (50, 0.0f, Screen.width, Screen.height / 3), typewriterText);
		}
	}
}