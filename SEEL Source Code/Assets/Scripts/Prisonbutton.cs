using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOutcome2 : MonoBehaviour
{
    private Renderer renderer;
    public VictimManager manager;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseUpAsButton()
    {
        manager.PrisonChoice();
    }
}
