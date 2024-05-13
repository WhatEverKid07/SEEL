using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPhotoCamera : MonoBehaviour
{
    public Color outlineRed;
    public PhotoCamera photoCamera;
    public Renderer buttonHighlightRenderer;
    public Animator animator;
    public GameObject cameraOutline;

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
        animator.SetTrigger("SNAP");
        cameraOutline.SetActive(false);
    }
}
