using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NextVictim : MonoBehaviour
{
    private Renderer button4Renderer;
    public VictimManager manager;
    public Animator animator;

    public Renderer buttonHighlightRenderer;

    void Start()
    {
        button4Renderer = GetComponent<Renderer>();
    }

    private void OnMouseUpAsButton()
    {
        animator.SetTrigger("NewVictim");
        manager.GetNextPerson();
    }
    private void OnMouseExit()
    {
        buttonHighlightRenderer.material.color = Color.clear;
    }
}
