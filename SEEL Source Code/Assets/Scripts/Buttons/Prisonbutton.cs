using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOutcome2 : MonoBehaviour
{
    public VictimManager manager;
    public Animator animator;

    public Renderer buttonHighlightRenderer;

    private void OnMouseUpAsButton()
    {
        animator.SetTrigger("Jail Stamp");
        manager.PrisonChoice();
        buttonHighlightRenderer.material.color = Color.clear;
    }
}
