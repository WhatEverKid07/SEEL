using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject background;
    public static bool gameIsPaused = false;
    public List<GameObject> camButtons;
    public bool curserLock;
    public List<GameObject> chosenCamButtons;

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
        if(curserLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        foreach (GameObject ChosenCamButtons in chosenCamButtons.ToArray())
        {
            ChosenCamButtons.SetActive(true);
            camButtons.Add(ChosenCamButtons);
            chosenCamButtons.Remove(ChosenCamButtons);
        }
    }
       
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        AudioListener.pause = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        background.SetActive(true);
        gameIsPaused = true;
        foreach (GameObject CamButtons in camButtons.ToArray())
        {
            if (CamButtons.activeInHierarchy)
            {
                CamButtons.gameObject.SetActive(false);
                chosenCamButtons.Add(CamButtons);
                camButtons.Remove(CamButtons);

            }
        }
    }
}
