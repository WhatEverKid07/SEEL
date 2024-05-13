using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TakeTheDamnPhoto : MonoBehaviour
{
    public PhotoCamera photoCameraScript;
    public void TakePhoto()
    {
        photoCameraScript.Photo();
    }
}
