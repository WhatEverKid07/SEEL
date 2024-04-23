using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class DemoEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BackToStart());
    }

    IEnumerator BackToStart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Start Menu");
    }
}
