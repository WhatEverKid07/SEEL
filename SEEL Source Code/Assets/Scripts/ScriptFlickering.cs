using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFlickering : MonoBehaviour
{
    public MonoBehaviour lightScript;
    public AudioSource lightSFX;
    public float minToggleInterval = 1.0f;
    public float maxToggleInterval = 5.0f;

    private bool isScriptActive = true;

    void Start()
    {
        // Start the toggling coroutine
        StartCoroutine(ToggleScript());
    }

    IEnumerator ToggleScript()
    {
        while (true)
        {
            // Toggle the script on or off
            isScriptActive = !isScriptActive;
            lightScript.enabled = isScriptActive;
            lightSFX.enabled = isScriptActive;

            // Wait for a random interval before toggling again
            yield return new WaitForSeconds(Random.Range(minToggleInterval, maxToggleInterval));
        }
    }
}