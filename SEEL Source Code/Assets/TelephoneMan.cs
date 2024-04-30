using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneMan : MonoBehaviour
{
    public CamScript cameraScript;
    public VictimManager victimManager;
    public AudioSource dialouge;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraScript.leftSide = true;
        cameraScript.rightSide = false;
        cameraScript.centre = false;
        cameraScript.LeftTurn();
    }

    private void Update()
    {
        if (start)
        {
            victimManager.enabled = true;
        }
        else { victimManager.enabled = false;}
    }
}
