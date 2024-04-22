using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentButton : MonoBehaviour
{
    private Renderer documentButton;
    public Document documentScript;
    public Animator documentAnimator;
    public Transform documentUI;
    //public Transform documentUIs[];
    public List<Transform> documents;
    public Color outlineRed;
    private bool canPickUp = true;

    private bool canPickUpDocument = true;

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
        if(canPickUp)
        {
            PickUp();
        }
        else 
        {
            PutDown();
        }
        //documentAnimator.SetTrigger("PickUpDocument");

    }
    void PickUp()
    {
        documentUI.gameObject.SetActive(true);
        canPickUp = false;
        /*
        documentAnimator.SetTrigger("PickUpDocument");
        StartCoroutine(OpenUI());
        */
    }
    void PutDown()
    {
        //documentAnimator.SetTrigger("PutDownDocument");
        documentUI.gameObject.SetActive(false);
        canPickUp = true;
    }

    IEnumerator OpenUI()
    {
        yield return new WaitForSeconds(1);
        documentUI.gameObject.SetActive(true);
    }
}
