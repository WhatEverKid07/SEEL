using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NextVictim : MonoBehaviour
{
    public VictimManager manager;
    public Animator animator;
    public Color outlineRed;

    public Renderer buttonHighlightRenderer;

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
        animator.SetTrigger("NewVictim");
        manager.RustyButtonActivate();
        gameObject.SetActive(false);
    }
    private void OnMouseExit()
    {
        buttonHighlightRenderer.material.color = Color.clear;
    }
}
