using UnityEngine;
using System.Collections;

public class CapFrames : MonoBehaviour 
{
	void Awake() {
		Application.targetFrameRate = 70;
	}
}