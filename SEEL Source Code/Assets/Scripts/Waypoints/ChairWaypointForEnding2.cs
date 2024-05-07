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
    public FadeForNextDay fadeForNextDay;
    public GameObject nextDay;
    public GameObject light;
    private bool canFade;
    public Animator animator;

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
        //fadeForNextDay.FadeIn();
        animator.SetTrigger("EndFade");
        light.SetActive(false);
        canFade = false;
    }
}
