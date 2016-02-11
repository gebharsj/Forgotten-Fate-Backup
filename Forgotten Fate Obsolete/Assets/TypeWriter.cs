using UnityEngine;
using System.Collections;

public class TypeWriter : MonoBehaviour
{
	public float textSpeed = 0.05f;
	
	float waitTimer = 0.0f;
	string wholeText = "This is a simple text. Is this fast enough for you Sam?";
	string typewriterText = "";
	int currentIndex = 0;
	
	void Update ()
	{
		waitTimer += Time.deltaTime;
		
		if (waitTimer > textSpeed && currentIndex < wholeText.Length)
		{            
			typewriterText += wholeText[currentIndex];
			waitTimer = 0.0f;
			++currentIndex;
		}      
	}
	
	void OnGUI()
	{
		GUI.TextArea(new Rect(0.0f, 0.0f, 300.0f, 100.0f), typewriterText);
	}
}