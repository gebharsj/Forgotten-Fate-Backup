using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	public GameObject pauseMenu;
	
	public void ResumeGame()
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
	}
}
