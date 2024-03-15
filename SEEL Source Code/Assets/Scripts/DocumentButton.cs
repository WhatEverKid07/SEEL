using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentButton : MonoBehaviour
{
    private Renderer renderer;
    public Document documentScript;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.clear;
    }
    private void OnMouseDown()
    {
        documentScript.start = true;
    }
}
