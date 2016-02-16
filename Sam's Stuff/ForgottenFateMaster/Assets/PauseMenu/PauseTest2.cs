using UnityEngine;
using System.Collections;

public class PauseTest2 : MonoBehaviour {

	public GameObject pauseMenu;
	bool paused = false;
	
	void Start ()
	{
		Screen.lockCursor = true;
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
			Screen.lockCursor = true;
			Time.timeScale = 1;
			return(false);
		}
		else
		{
			Screen.lockCursor = false;
			Time.timeScale = 0;
			return(true);
		}
	}
}
