using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NextVictim : MonoBehaviour
{
    public VictimManager manager;
    public CamScript cameraScript;
    public Animator animator;
    public Color outlineRed;
    public Renderer buttonHighlightRenderer;
    public AudioSource buttonClick;

    void Start()
    {
        buttonHighlightRenderer = GetComponent<Renderer>();
    }
    private void OnMouseEnter()
    {
        buttonHighlightRenderer.material.color = outlineRed;
    }
    private void OnMouseUpAsButton()
    {
        buttonClick.Play();
        animator.SetTrigger("NewVictim");
        manager.RustyButtonActivate();
        gameObject.SetActive(false);
        buttonHighlightRenderer.material.color = Color.clear;
        /*
        cameraScript.leftSide = false;
        cameraScript.rightSide = true;
        cameraScript.centre = false;
        cameraScript.RightTurn();
        */
    }
    private void OnMouseExit()
    {
        buttonHighlightRenderer.material.color = Color.clear;
    }
}
