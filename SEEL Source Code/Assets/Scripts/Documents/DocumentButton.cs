using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentButton : MonoBehaviour
{
    private Renderer documentButton;
    public Document documentScript;
    public Animator documentAnimator;
    //public Transform documentUIs[];
    public List<Transform> documents;
    public Color outlineRed;

    private bool canPickUpDocument = true;

    void Start()
    {
        documentButton = GetComponent<Renderer>();
        documentAnimator.SetBool("CanPickUpDocument", true);
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
        documentAnimator.SetTrigger("PickUpDocument");

        foreach (Transform t in documents)
        {
            //documents.
        }
        /*
        if (canPickUpDocument)
        {
            PickUpDocument();
        }
        if(!canPickUpDocument)
        {
            PutDownDocument();
        }
        */
    }
    /*
    void PickUpDocument()
    {

        documentAnimator.SetBool("CanPickUpDocument", true);
        //canPickUpDocument = false;
    }
    void PutDownDocument()
    {
        documentAnimator.SetTrigger("PutDownDocument");
        documentAnimator.SetBool("CanPickUpDocument", false);
        //canPickUpDocument = true;
    }
        */
}
