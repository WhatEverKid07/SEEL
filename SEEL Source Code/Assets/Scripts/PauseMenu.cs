using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject background;
    public static bool gameIsPaused = false;
    public List<GameObject> camButtons;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        foreach (GameObject CamButtons in camButtons)
        {
            CamButtons.SetActive(true);
        }
    }
       
    void Pause()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        background.SetActive(true);
        gameIsPaused = true;
        foreach (GameObject CamButtons in camButtons)
        {
            CamButtons.SetActive(false);
        }
    }
}
