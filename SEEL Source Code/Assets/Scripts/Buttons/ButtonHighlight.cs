using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public Color outlineRed;

    public Renderer buttonHighlightRenderer;
    public Transform buttonText;
    
    void Start()
    {
        buttonHighlightRenderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        buttonHighlightRenderer.material.color = outlineRed;
        buttonText.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        buttonHighlightRenderer.material.color = Color.clear;
        buttonText.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        buttonText.gameObject.SetActive(false);
    }
}
