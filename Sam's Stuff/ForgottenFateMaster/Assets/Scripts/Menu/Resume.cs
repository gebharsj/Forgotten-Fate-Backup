using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	public GameObject pauseMenu;
    public GameObject statusHUD;
    public GameObject spells;
	
	public void ResumeGame()
	{
		pauseMenu.SetActive (false);
        statusHUD.SetActive(true);
        spells.SetActive(true);
		Time.timeScale = 1;
	}
}
