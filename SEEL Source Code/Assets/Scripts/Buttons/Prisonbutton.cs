using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOutcome2 : MonoBehaviour
{
    private Renderer button2Renderer;
    public VictimManager manager;

    void Start()
    {
        button2Renderer = GetComponent<Renderer>();
    }

    private void OnMouseUpAsButton()
    {
        manager.PrisonChoice();
    }
}
