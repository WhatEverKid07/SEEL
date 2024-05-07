using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeForNextDay : MonoBehaviour
{
    public Animator fade;
    public bool fadeIn;

    private void Start()
    {
        if (fadeIn)
        {
            fade.SetTrigger("FadeIn");
        }
    }
    public void BlackOut()
    {
        fade.SetTrigger("BlackOut");
    }
    public void FadeIn()
    {
        fade.SetTrigger("FadeIn");
    }
}
