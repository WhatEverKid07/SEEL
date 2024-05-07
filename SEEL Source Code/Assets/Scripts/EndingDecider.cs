using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class EndingDecider : MonoBehaviour
{
    // Start is called before the first frame update
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
            SceneManager.LoadScene("Ending 1");
        }
        else if (VictimManager.fateNumber >= 0 && VictimManager.fateNumber < 7)
        {
            SceneManager.LoadScene("Ending 2");
        }
        else if (VictimManager.fateNumber < 0)
        {
            SceneManager.LoadScene("Ending 3");
        }
    }
    IEnumerator BackToStart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Start Menu");
    }
}
