using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document_DrawerAnimationController : MonoBehaviour
{
    [Header("Animator Controllers")]
    public Animator drawerOpener;
    public Animator documentAnimatorController;
    public AudioSource drawer;
    public AudioSource documentShuffle;

    public void TakeOutDocument()
    {
        drawer.Play();
        drawerOpener.SetTrigger("Open_Close Drawer");
        documentShuffle.PlayDelayed(0.5f);
        documentAnimatorController.SetTrigger("TakeOutDocument");
    }
    public void PutAwayDocument()
    {
        Debug.Log("PutAwayDocumentScript mwawawaw");
        drawer.Play();
        drawerOpener.SetTrigger("Open_Close Drawer");
        documentShuffle.PlayDelayed(0.5f);
        documentAnimatorController.SetTrigger("PutAwayDocument");  
    }
}
