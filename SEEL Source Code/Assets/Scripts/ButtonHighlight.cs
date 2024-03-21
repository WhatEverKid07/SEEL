using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer buttonHighlightRenderer;

    void Start()
    {
        buttonHighlightRenderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        buttonHighlightRenderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        buttonHighlightRenderer.material.color = Color.clear;
    }
}
