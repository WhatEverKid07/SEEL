using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPhotoCamera : MonoBehaviour
{
    public Color outlineRed;
    public PhotoCamera photoCameraScript;
    public Renderer buttonHighlightRenderer;
    public Animator animator;
    public GameObject cameraOutline;
    public VictimManager victimManager;

    private void Start()
    {
        NewCharacter();
    }
    public void NewCharacter()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
   
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
