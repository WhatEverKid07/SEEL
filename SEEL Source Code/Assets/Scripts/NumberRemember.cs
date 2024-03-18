using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRemember : MonoBehaviour
{
    public static int number;

    public void AddPoints()
    {
        number += 5;
        Debug.Log(number);
    }
}
