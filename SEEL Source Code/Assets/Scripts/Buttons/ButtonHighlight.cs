using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public Color outlineRed;

    public Renderer buttonHighlightRenderer;
    public GameObject blankText;
    public GameObject stampTextforSign;
    
    void Start()
    {
        buttonHighlightRenderer = GetComponent<Renderer>();
        //blankText.GetComponent<MeshRenderer>().material = originalBlank;
        //currentStamp = originalBlank;
    }

    private void OnMouseEnter()
    {
        buttonHighlightRenderer.material.color = outlineRed;

        //currentStamp = stampText;
        blankText.gameObject.SetActive(false);
        stampTextforSign.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        buttonHighlightRenderer.material.color = Color.clear;

        //currentStamp = originalBlank;
        blankText.gameObject.SetActive(true);
        stampTextforSign.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        //currentStamp = originalBlank;
        blankText.gameObject.SetActive(true);
        stampTextforSign.gameObject.SetActive(false);
    }
}
