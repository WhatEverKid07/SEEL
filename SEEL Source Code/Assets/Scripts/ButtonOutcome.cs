using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOutcome : MonoBehaviour
{
    private Renderer renderer;
    public LolTest lolTest;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        renderer.material.color = Color.red;
        if (lolTest.isOn == true)
        {
            lolTest.Outcome1();
        }
    }

    private void OnMouseUp()
    {
        renderer.material.color = Color.green;
        
    }
}