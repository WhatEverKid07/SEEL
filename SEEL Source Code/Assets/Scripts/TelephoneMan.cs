using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TelephoneMan : MonoBehaviour
{
    public CamScript cameraScript;
    public SpeedUpBoss speedUpBoss;
    public Text spacebarToSpeed;
    public VictimManager victimManager;
    public AudioSource dialouge;
    public GameObject computerScreen;
    public float boss;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        boss = dialouge.clip.length;
        cameraScript.nothing = true;
        dialouge.Play();
        StartCoroutine(ComputerTutorial());
        StartCoroutine(RightWindow());
        StartCoroutine(StartFirstDay());
    }

    IEnumerator ComputerTutorial()
    {
        yield return new WaitForSeconds(31);
        cameraScript.nothing = true;
        cameraScript.LeftTurn();

        yield return new WaitForSeconds(2);
        computerScreen.SetActive(true);
    }
    IEnumerator RightWindow()
    {
        yield return new WaitForSeconds(50);
        computerScreen.SetActive(false);
        cameraScript.LeftTurn2();

        yield return new WaitForSeconds(0.5f);
        cameraScript.RightTurn();
    }
    IEnumerator StartFirstDay()
    {
        yield return new WaitForSeconds(boss);
        Debug.Log("PLAY");
        victimManager.gameObject.SetActive(true);
        speedUpBoss.gameObject.SetActive(false);
        spacebarToSpeed.gameObject.SetActive(false);
        cameraScript.rightSide = true;
        cameraScript.nothing = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        speedUpBoss.audioMixer.SetFloat(speedUpBoss.pitchParameter, 1f);
        pauseMenu.curserLock = false;
    }
}
