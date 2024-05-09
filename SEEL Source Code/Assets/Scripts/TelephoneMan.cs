    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneMan : MonoBehaviour
{
    public CamScript cameraScript;
    public VictimManager victimManager;
    public AudioSource dialouge;
    public GameObject computerScreen;
    public float boss;
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
        cameraScript.rightSide = true;
        cameraScript.nothing = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
