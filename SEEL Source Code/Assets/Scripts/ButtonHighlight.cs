using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        renderer.material.color = Color.red;
        Debug.Log("pressed");
    }

    private void OnMouseUp()
    {
        renderer.material.color = Color.green;
        Debug.Log("let go");
    }
}
