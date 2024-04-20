using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOutcome2 : MonoBehaviour
{
    private Renderer button2Renderer;
    public VictimManager manager;
    public Animator animator;

    public Renderer buttonHighlightRenderer;

    void Start()
    {
        button2Renderer = GetComponent<Renderer>();
    }

    private void OnMouseUpAsButton()
    {
        animator.SetTrigger("Jail Stamp");
        manager.PrisonChoice();
        buttonHighlightRenderer.material.color = Color.clear;
    }
}
