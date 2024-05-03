using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ComputerScript: MonoBehaviour
{
    public Color outlineRed;
    public Renderer buttonHighlightRenderer;
    public Transform computerScreen;
    public List<Transform> camButtons;
    public Transform leavePCButton;
    public AudioSource openSFX;
    
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

    private void OnMouseDown()
    {
        computerScreen.gameObject.SetActive(true);
        leavePCButton.gameObject.SetActive(true);
        buttonHighlightRenderer.material.color = Color.clear;
        foreach (Transform t in camButtons)
        {
            gameObject.SetActive(false);
        }
        openSFX.Play();
    }

    public void LeavePCScreen()
    {
        computerScreen.gameObject.SetActive(false );
        leavePCButton.gameObject.SetActive(false);
        foreach (Transform t in camButtons)
        {
            gameObject.SetActive(true);
        }
    }
}
