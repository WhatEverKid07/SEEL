using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class FirstWaypointForEnding2 : MonoBehaviour
{
    public FirstWaypoint firstWaypoint;
    public AudioSource footsteps;
    public GameObject nextDay;
    public GameObject image;
    public GameObject light;
    private bool canFade;
    public GameObject pressSpaceText;

    private void Start()
    {
        canFade = false;
    }
    private void Update()
    {
        if (firstWaypoint.AA && !canFade)
        {
            canFade = true;
        }
        if (firstWaypoint.AA && canFade)
        {
            footsteps.Stop();
            StartCoroutine(NextDay());
        }
    }
    IEnumerator NextDay()
    {
        yield return new WaitForSeconds(2);
        nextDay.SetActive(true);
        light.SetActive(false);
        yield return new WaitForSeconds(1);
        image.SetActive(true);
        canFade = false;
        yield return new WaitForSeconds(5);
        pressSpaceText.SetActive(true);
    }
}
