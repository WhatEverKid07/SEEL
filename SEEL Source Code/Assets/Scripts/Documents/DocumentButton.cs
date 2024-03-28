using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentButton : MonoBehaviour
{
    private Renderer documentButton;
    public Document documentScript;

    void Start()
    {
        documentButton = GetComponent<Renderer>();
    }
    private void OnMouseEnter()
    {
        documentButton.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        documentButton.material.color = Color.clear;
    }
    private void OnMouseDown()
    {
        documentScript.start = true;
    }
}
