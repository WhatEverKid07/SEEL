using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOutcome3 : MonoBehaviour
{
    private Renderer button3Renderer;
    public VictimManager manager;

    void Start()
    {
        button3Renderer = GetComponent<Renderer>();
    }

    private void OnMouseUpAsButton()
    {
        manager.DeathChoice();
    }
}
