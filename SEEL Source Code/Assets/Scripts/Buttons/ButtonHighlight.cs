using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Color outlineRed;

    private Renderer buttonHighlightRenderer;
    
    void Start()
    {
        buttonHighlightRenderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        buttonHighlightRenderer.material.color = outlineRed;
    }

    private void OnMouseExit()
    {
        buttonHighlightRenderer.material.color = Color.clear;
    }
}
