using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamScript : MonoBehaviour
{
    public Transform mainCam;

    [Header("---Document---")]
    public Transform documentOutline;
    public Transform documentOutline2;
    public Transform documentOutline3;
    public Transform documentOutline4;
    public Transform documentOutline5;

    [Header("---Stamp Outlines---")]
    public Transform freedomStampOutline;
    public Transform prisonStampOutline;
    public Transform deathStampOutline;

    [Header("---Buttons---")]
    public Button leftTurnButton;
    public Button leftTurnButton2;
    public Button rightTurnButton;
    public Button rightTurnButton2;
    //public Button bottomTurnButton;
    //public Button topTurnButton;

    [Header("---Rotation---")]
    public float turnSpeed = 1.0f;
    public float leftRotation;
    public float leftRotationDown;
    public float rightRotation;
    public float rightRotationDown;
    public float bottomRotation;

    public bool centre = true;
    public bool leftSide = false;
    public bool rightSide = false;
    public bool bottomSide = false;
    public bool nothing = false;

    void Start()
    {
        /*
        centre = true;
        leftSide = false;
        rightSide = false;
        bottomSide = false;
        */
    }
    void Update()
    {
        if (centre == true)
        {
            Centre();
        }
        if (leftSide == true)
        {
            LeftSide();
        }
        if (rightSide == true)
        {
            RightSide();
        }
        if (bottomSide == true)
        {
            BottomSide();
        }
        if (nothing)
        {
            leftTurnButton.gameObject.SetActive(false);
            leftTurnButton2.gameObject.SetActive(false);
            rightTurnButton.gameObject.SetActive(false);
            rightTurnButton2.gameObject.SetActive(false);
        }
    }

    public void LeftTurn()
    {
        Vector3 currentRotation = mainCam.transform.eulerAngles;
        mainCam.transform.eulerAngles = new Vector3(currentRotation.x + leftRotationDown, currentRotation.y + leftRotation, currentRotation.z);
        centre = false;
        leftSide = true;
    }
    public void LeftTurn2()
    {
        Vector3 currentRotation = mainCam.transform.eulerAngles;
        mainCam.transform.eulerAngles = new Vector3(currentRotation.x - leftRotationDown, currentRotation.y - leftRotation, currentRotation.z);
        leftSide = false;
        centre = true;
    }
    public void RightTurn()
    {
        Vector3 currentRotation = mainCam.transform.eulerAngles;
        mainCam.transform.eulerAngles = new Vector3(currentRotation.x + rightRotationDown, currentRotation.y + rightRotation, currentRotation.z);
        centre = false;
        rightSide = true;
    }
    public void RightTurn2()
    {
        Vector3 currentRotation = mainCam.transform.eulerAngles;
        mainCam.transform.eulerAngles = new Vector3(currentRotation.x - rightRotationDown, currentRotation.y - rightRotation, currentRotation.z);
        rightSide = false;
        centre = true;
    }
    public void BottomTurn()
    {
        Vector3 currentRotation = mainCam.transform.eulerAngles;
        mainCam.transform.eulerAngles = new Vector3(currentRotation.x + bottomRotation, currentRotation.y, currentRotation.z);
        centre = false;
        bottomSide = true;
    }
    public void UpTurn()
    {
        Vector3 currentRotation = mainCam.transform.eulerAngles;
        mainCam.transform.eulerAngles = new Vector3(currentRotation.x + -bottomRotation, currentRotation.y, currentRotation.z);
        bottomSide = false;
        centre = true;
    }
    void Centre()
    {
        leftTurnButton.gameObject.SetActive(true);
        leftTurnButton2.gameObject.SetActive(false);
        rightTurnButton.gameObject.SetActive(true);
        rightTurnButton2.gameObject.SetActive(false);
        //bottomTurnButton.gameObject.SetActive(true);
        //topTurnButton.gameObject.SetActive(false);

        documentOutline.gameObject.SetActive(true);
        documentOutline2.gameObject.SetActive(true);
        documentOutline3.gameObject.SetActive(true);
        documentOutline4.gameObject.SetActive(true);
        documentOutline5.gameObject.SetActive(true);

        /*
        freedomStampOutline.gameObject.SetActive(true);
        prisonStampOutline.gameObject.SetActive(true);
        deathStampOutline.gameObject.SetActive(true);
        */
    }
    void LeftSide()
    {
        leftTurnButton.gameObject.SetActive(false);
        leftTurnButton2.gameObject.SetActive(true);
        rightTurnButton.gameObject.SetActive(false);
        rightTurnButton2.gameObject.SetActive(false);
        //bottomTurnButton.gameObject.SetActive(false);
        //topTurnButton.gameObject.SetActive(false);

        documentOutline.gameObject.SetActive(false);
        documentOutline2.gameObject.SetActive(false);
        documentOutline3.gameObject.SetActive(false);
        documentOutline4.gameObject.SetActive(false);
        documentOutline5.gameObject.SetActive(false);

        /*
        freedomStampOutline.gameObject.SetActive(false);
        prisonStampOutline.gameObject.SetActive(false);
        deathStampOutline.gameObject.SetActive(false);
        */
    }
    void RightSide()
    {
        rightTurnButton.gameObject.SetActive(false);
        rightTurnButton2.gameObject.SetActive(true);
        leftTurnButton.gameObject.SetActive(false);
        leftTurnButton2.gameObject.SetActive(false);
        //bottomTurnButton.gameObject.SetActive(false);
        //topTurnButton.gameObject.SetActive(false);

        documentOutline.gameObject.SetActive(false);
        documentOutline2.gameObject.SetActive(false);
        documentOutline3.gameObject.SetActive(false);
        documentOutline4.gameObject.SetActive(false);
        documentOutline5.gameObject.SetActive(false);

        /*
        freedomStampOutline.gameObject.SetActive(false);
        prisonStampOutline.gameObject.SetActive(false);
        deathStampOutline.gameObject.SetActive(false);
        */
    }
    void BottomSide()
    {
        leftTurnButton.gameObject.SetActive(false);
        leftTurnButton2.gameObject.SetActive(false);
        rightTurnButton.gameObject.SetActive(false);
        rightTurnButton2.gameObject.SetActive(false);
        //bottomTurnButton.gameObject.SetActive(false);
        //topTurnButton.gameObject.SetActive(true);

        documentOutline.gameObject.SetActive(true);
        documentOutline2.gameObject.SetActive(true);
        documentOutline3.gameObject.SetActive(true);
        documentOutline4.gameObject.SetActive(true);
        documentOutline5.gameObject.SetActive(true);
    }
}
