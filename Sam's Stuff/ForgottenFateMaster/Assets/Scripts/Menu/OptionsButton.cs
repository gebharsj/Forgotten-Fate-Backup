using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsButton : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject optionsMenu;

	public void OptionsMenu()
	{
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
	}
}
