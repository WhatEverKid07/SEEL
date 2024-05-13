using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TakeTheDamnPhoto : MonoBehaviour
{
    public PhotoCamera photoCameraScript;
    public VictimManager victimManager;

    private void Start()
    {
        NewCharacter();
    }
    public void NewCharacter()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
    public void TakePhoto()
    {
        photoCameraScript.Photo();
        Debug.Log("TakeTheDamnPhoto");
    }
}
