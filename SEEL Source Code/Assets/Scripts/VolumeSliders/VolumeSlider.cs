using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider allSound;
    public Slider musicSlider;
    public Slider SFX_Slider;
    public Slider dialogueSlider;

    public static float allAudioSliderVolumeStatic;
    public static float musicSliderVolumeStatic;
    public static float SFX_SliderVolumeStatic;
    public static float dialogueVolumeStatic;

    public  float allAudioSliderVolume;
    public  float musicSliderVolume;
    public  float SFX_SliderVolume;
    public  float dialogueVolume;

    public AudioMixer musicMixer;
    //public AudioSource[] allAudioSources; // Array to hold all audio sources
    //public AudioSource[] music; // Array to hold all audio sources
    //public AudioSource[] SFX; // Array to hold all audio sources

    public bool isGameScene;

    private void Start()
    {
        if (!isGameScene)
        {
            allSound.value = 1;
            musicSlider.value = 1;
            SFX_Slider.value = 1;
            dialogueSlider.value = 1;
        }
        else
        {
            musicMixer.SetFloat("Master",allSound.value);
            musicMixer.SetFloat("SFX",SFX_Slider.value);
            musicMixer.SetFloat("Music",musicSlider.value);
            musicMixer.SetFloat("Dialogue",dialogueSlider.value);

            allSound.value = allAudioSliderVolumeStatic;
            musicSlider.value = musicSliderVolumeStatic;
            SFX_Slider.value = SFX_SliderVolumeStatic;
            dialogueSlider.value = dialogueVolumeStatic;
        }


        /*
        //Time.timeScale = 0;
        allSound.value = 1;
        musicSlider.value = 1;
        SFX_Slider.value = 1;
        allAudioSliderVolume = allSound.value;
        musicSliderVolume = musicSlider.value;
        SFX_SliderVolume = SFX_Slider.value;
        Debug.Log(allAudioSliderVolume);
        Debug.Log(musicSliderVolume);
        Debug.Log(SFX_SliderVolume);
        */
    }


    private void Update()
    {
        musicMixer.SetFloat("Master", allSound.value);
        musicMixer.SetFloat("SFX", SFX_Slider.value);
        musicMixer.SetFloat("Music", musicSlider.value);
        musicMixer.SetFloat("Dialogue", dialogueSlider.value);

        allAudioSliderVolumeStatic = allSound.value;
        musicSliderVolumeStatic = musicSlider.value;
        SFX_SliderVolumeStatic = SFX_Slider.value;
        dialogueVolumeStatic = dialogueSlider.value;

        allAudioSliderVolume = allAudioSliderVolumeStatic;
        musicSliderVolume = musicSliderVolumeStatic;
        SFX_SliderVolume = SFX_SliderVolumeStatic;
        dialogueVolume = dialogueVolumeStatic;

        /*
        foreach (AudioSource source in allAudioSources)
        {
            source.volume = allAudioSliderVolume;
            //Debug.Log("Global Audio" + allAudioSliderVolume);
        }
        foreach (AudioSource source in music)
        {
            source.volume = musicSliderVolume;
            //Debug.Log("music Volume" + musicSliderVolume);
        }
        foreach (AudioSource source in SFX)
        {
            source.volume = SFX_SliderVolume;
            //Debug.Log("SFX Volume" + SFX_SliderVolume);
        }
        */
    }
}