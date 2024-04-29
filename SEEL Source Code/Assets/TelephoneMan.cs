using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneMan : MonoBehaviour
{
    public CamScript cameraScript;

    public AudioSource dialouge;
    // Start is called before the first frame update
    void Start()
    {
        cameraScript.leftSide = true;
        cameraScript.rightSide = false;
        cameraScript.centre = false;
        cameraScript.LeftTurn();
    }

}
