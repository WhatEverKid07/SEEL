using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentButton : MonoBehaviour
{
    private Renderer documentButton;
    public Animator documentAnimator;
    public Transform documentUI;

    public GameObject[] camButtons;
    public Color outlineRed;

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
        documentAnimator.SetTrigger("PickUpDocument");
        foreach (GameObject button in camButtons)
        {
            button.SetActive(false);
        }
        StartCoroutine(OpenUI());
    }
    IEnumerator OpenUI()
    {
        yield return new WaitForSeconds(1);
        documentUI.gameObject.SetActive(true);
    }
}
