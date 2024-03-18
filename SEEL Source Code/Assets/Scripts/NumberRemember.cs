using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRemember : MonoBehaviour
{
    public static int fateNumber;
    public int wrongChoice;
    public int bigWrongChoice;

    public void WrongChoice()
    {
        fateNumber += wrongChoice;
        Debug.Log(fateNumber);
    }
    public void BigWrongChoice()
    {
        fateNumber += bigWrongChoice;
        Debug.Log(fateNumber);
    }
}
