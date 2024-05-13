using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SpeedUpBoss : MonoBehaviour
{
    public Text spaceBarText;
    public float speedMultiplier = 2f;
    private bool isSpeedingUp = false;
    public AudioMixer audioMixer;
    public string pitchParameter = "Pitch";

    private void Start()
    {
        StartCoroutine(PressSpacebar());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = speedMultiplier;
            audioMixer.SetFloat(pitchParameter, speedMultiplier);
            isSpeedingUp = true;
        }
        else
        {
            if (isSpeedingUp)
            {
                Time.timeScale = 1f;
                audioMixer.SetFloat(pitchParameter, 1f);
                isSpeedingUp = false;
            }
        }
    }
IEnumerator PressSpacebar()
    {
        yield return new WaitForSeconds(4);
        spaceBarText.gameObject.SetActive(true);
    }
}
