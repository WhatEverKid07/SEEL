using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class EndingDecider : MonoBehaviour
{
    public bool resetCounter = false;

    void Start()
    {
        StartCoroutine(DecideEnd());
        Debug.Log("FINAL SCORE" + VictimManager.fateNumber);
    }

    IEnumerator DecideEnd()
    {
        yield return new WaitForSeconds(2);
        if(VictimManager.fateNumber >= 7)
        {
            VictimManager.fateNumber = 0;
            SceneManager.LoadScene("Ending 3");
        }
        else if (VictimManager.fateNumber >= 0 && VictimManager.fateNumber < 7)
        {
            VictimManager.fateNumber = 0;
            SceneManager.LoadScene("Ending 1");
        }
        else if (VictimManager.fateNumber < 0)
        {
            VictimManager.fateNumber = 0;
            SceneManager.LoadScene("Ending 2");
        }
    }
}
