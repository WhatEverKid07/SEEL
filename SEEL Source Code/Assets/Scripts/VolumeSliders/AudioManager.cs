using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static float globalVolume = 1.0f; // Static number to control volume
    public static float musicVolume = 1.0f; // Static number to control volume
    public static float SFX_Volume = 1.0f; // Static number to control volume

    public AudioSource[] allAudioSources; // Array to hold all audio sources
    public AudioSource[] music; // Array to hold all audio sources
    public AudioSource[] SFX; // Array to hold all audio sources

    // Update is called once per frame
    void Update()
    {
        // Check if GlobalVolume has changed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            globalVolume += 0.1f; // Increase volume
            UpdateAudioVolume();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            globalVolume -= 0.1f; // Decrease volume
            UpdateAudioVolume();
        }
    }

    // Function to update volume of all audio sources
    void UpdateAudioVolume()
    { 
        /*
        // Ensure GlobalVolume stays within range
        globalVolume = Mathf.Clamp01(globalVolume);
        musicVolume = Mathf.Clamp01(musicVolume);
        SFX_Volume = Mathf.Clamp01(SFX_Volume);
        */
        // Loop through each audio source and update volume
        foreach (AudioSource source in allAudioSources)
        {
            source.volume = globalVolume;
        }
        foreach (AudioSource source in music)
        {
            source.volume = musicVolume;
        }
        foreach (AudioSource source in SFX)
        {
            source.volume = SFX_Volume;
        }
    }
}
