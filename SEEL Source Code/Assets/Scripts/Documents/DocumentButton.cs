using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentButton : MonoBehaviour
{
    private Renderer documentButton;
    public Animator documentAnimator;
    public Transform documentUI;
    public AudioSource documentShuffle;

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
        gameObject.SetActive(false);
        documentShuffle.Play();
        //documentAnimator.SetTrigger("PickUpDocument");
        foreach (GameObject button in camButtons)
        {
            button.SetActive(false);
        }
        documentUI.gameObject.SetActive(true);
        documentButton.material.color = Color.clear;
        //StartCoroutine(OpenUI());
    }
    IEnumerator OpenUI()
    {
        yield return new WaitForSeconds(1);
        documentUI.gameObject.SetActive(true);
    }
}
