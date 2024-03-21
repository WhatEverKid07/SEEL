using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOutcome : MonoBehaviour
{
    private Component buttonRenderer;
    public VictimManager manager;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
    }

    private void OnMouseUpAsButton()
    {
        manager.FreedomChoice();
    }
}
