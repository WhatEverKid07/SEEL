using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DoorAnimationControl : MonoBehaviour
{
    public VictimManager VictimManager;
    public Animator rightDoorAnimation;
    public Animator leftDoorAnimation;

    public GameObject rightDoor;
    public GameObject leftDoor;

    public AudioSource doorOpening;
    public AudioSource doorClosing;
    public AudioSource peopleChatter;

    private void Start()
    {
        rightDoorAnimation = rightDoor.GetComponent<Animator>();
        leftDoorAnimation = leftDoor.GetComponent<Animator>();
        //rightDoorAnimation.SetTrigger("RightOpen");
    }
    public void OpenRightDoor()
    {
        rightDoorAnimation.SetTrigger("RightOpen");
        peopleChatter.PlayDelayed(0.2f);
        doorOpening.PlayDelayed(0.75f);
        Debug.Log("OpenRightDoor");
    }
    public void OpenLeftDoor()
    {
        leftDoorAnimation.SetTrigger("LeftOpen");
        doorOpening.PlayDelayed(0.29f);
        Debug.Log("OpenLeftDoor");
    }
    public void CloseRightDoor()
    {
        rightDoorAnimation.SetTrigger("RightClose");
        doorClosing.PlayDelayed(1.77f);
        Debug.Log("CloseRightDoor");
    }
    public void CloseLeftDoor()
    {
        leftDoorAnimation.SetTrigger("LeftClose");
        doorClosing.PlayDelayed(1f);
        Debug.Log("CloseLeftDoor");
    }
}