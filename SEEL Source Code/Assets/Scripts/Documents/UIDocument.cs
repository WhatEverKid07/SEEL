using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDocument : MonoBehaviour
{
    private Renderer documentButton;
    public DocumentButton documentScript;
    public Animator documentAnimator;
    public Transform documentUI;
    public List<Transform> documents;
    public Color outlineRed;

    //private bool canPickUpDocument = true;

    void Start()
    {
        documentButton = GetComponent<Renderer>();
    }
    private void OnMouseEnter()
    {
        documentButton.material.color = outlineRed;
    }

    private void OnMouseExit()
    {
        documentButton.material.color = Color.clear;
    }
    private void OnMouseDown()
    {
        documentAnimator.SetTrigger("PutDownDocument");
        documentUI.gameObject.SetActive(false);
    }
}
