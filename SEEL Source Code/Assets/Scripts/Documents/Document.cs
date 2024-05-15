using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Document : MonoBehaviour
{
    public Animator documentAnimator;
    public GameObject documentUI;
    public GameObject hideStampOutline;
    public GameObject[] camButtons;

    private void Start()
    {
        GameObject parentObject = transform.parent.gameObject;

         documentUI = parentObject;
    }
    public void CloseDocument()
    {
        //documentAnimator.SetTrigger("PutDownDocument");
        documentUI.gameObject.SetActive(false);
        hideStampOutline.gameObject.SetActive(false);
        foreach (GameObject button in camButtons)
        {
            button.SetActive(true);
        }
        //Debug.Log("Close Document");
    }
}
