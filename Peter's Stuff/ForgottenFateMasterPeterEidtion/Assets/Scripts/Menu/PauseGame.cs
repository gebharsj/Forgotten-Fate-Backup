using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	public GameObject pauseMenu;
	bool paused = false;
	
	void Start ()
	{
		Time.timeScale = 1;
	}

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			paused = togglePause ();
			if (paused)
			{
				pauseMenu.SetActive(true);
			}
			else
			{
				pauseMenu.SetActive(false);
			}
		}		
	}
	
	bool togglePause()
	{
		if(Time.timeScale == 0)
		{
			Time.timeScale = 1;
			return(false);
		}
		else
		{
			Time.timeScale = 0;
			return(true);
		}
	}
}
