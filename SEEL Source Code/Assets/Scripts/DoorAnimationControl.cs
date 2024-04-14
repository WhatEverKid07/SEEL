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

    public GameObject rightDoorOpenActivator;
    public GameObject leftDoorCloseActivator;

    public AudioSource doorOpening;
    public AudioSource doorClosing;

    private void Start()
    {
        rightDoorAnimation = rightDoor.GetComponent<Animator>();
        leftDoorAnimation = leftDoor.GetComponent<Animator>();
        //rightDoorAnimation.SetTrigger("RightOpen");
    }
}