using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document_DrawerAnimationController : MonoBehaviour
{
    [Header("Animator Controllers")]
    public Animator drawerOpener;
    public Animator documentAnimatorController;

    public void TakeOutDocument()
    {
        drawerOpener.SetTrigger("Open_Close Drawer");
        documentAnimatorController.SetTrigger("TakeOutDocument");
    }
    public void PutAwayDocument()
    {
        Debug.Log("PutAwayDocumentScript mwawawaw");
        
        drawerOpener.SetTrigger("Open_Close Drawer");
        documentAnimatorController.SetTrigger("PutAwayDocument");
        
    }
}
