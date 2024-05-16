using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string gameScene;
    public GameObject nextDay;
    public FadeForNextDay fadeForNextDay;

    public void StartGame()
    {
        fadeForNextDay.BlackOut();
        StartCoroutine(NextDay());
    }
    IEnumerator NextDay()
    {
        yield return new WaitForSeconds(0.4f);
        nextDay.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(gameScene);
        Debug.Log("START");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
