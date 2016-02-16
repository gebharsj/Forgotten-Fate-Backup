using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	public GameObject pauseMenu;
	
	public void ResumeGame()
	{
		pauseMenu.SetActive (false);
		Screen.lockCursor = true;
		Time.timeScale = 1;
	}
}
