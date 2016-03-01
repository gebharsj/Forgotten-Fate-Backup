using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	public GameObject pauseMenu;
    public GameObject skills;
    public GameObject playerStatusHUD;

    public void ResumeGame()
	{
		pauseMenu.SetActive (false);
        skills.SetActive(true);
        playerStatusHUD.SetActive(true);
        Time.timeScale = 1;
	}
}
