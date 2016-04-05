using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject skills;
    public GameObject playerStatusHUD;
    bool paused = false;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            paused = togglePause();
            if (paused)
            {
                pauseMenu.SetActive(true);
                skills.SetActive(false);
                playerStatusHUD.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(false);
                skills.SetActive(true);
                playerStatusHUD.SetActive(true);
            }
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return (false);
        }
        else
        {
            Time.timeScale = 0;
            return (true);
        }
    }
}