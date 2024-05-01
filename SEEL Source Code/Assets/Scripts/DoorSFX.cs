using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSFX : MonoBehaviour
{
    public AudioSource doorOpening;
    public AudioSource doorClosing;

    public void OpenDoor()
    {
        doorOpening.Play();
    }
    public void CloseDoor()
    {
        doorClosing.Play();
    }
}