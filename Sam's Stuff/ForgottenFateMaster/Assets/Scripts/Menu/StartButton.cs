using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public void StartGame()
	{
		Debug.Log ("Game Starts");
		Application.LoadLevel ("testDemo");
	}
}
