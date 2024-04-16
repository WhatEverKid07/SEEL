using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider allSound;
    public Slider musicSlider;
    public Slider SFX_Slider;

    public static float allAudioSliderVolumeStatic;
    public static float musicSliderVolumeStatic;
    public static float SFX_SliderVolumeStatic;

    public  float allAudioSliderVolume;
    public  float musicSliderVolume;
    public  float SFX_SliderVolume;

    private void Start()
    {
        //Time.timeScale = 0;
        allAudioSliderVolume = allSound.value;
        musicSliderVolume = musicSlider.value;
        SFX_SliderVolume = SFX_Slider.value;
        Debug.Log(allAudioSliderVolume);
        Debug.Log(musicSliderVolume);
        Debug.Log(SFX_SliderVolume);
    }
    private void Awake()
    {
        allAudioSliderVolume = allAudioSliderVolumeStatic;
        musicSliderVolume = musicSliderVolumeStatic;
        SFX_SliderVolume = SFX_SliderVolumeStatic;
        Debug.Log("AWAKE");
        if (SFX_Slider.value != SFX_SliderVolume)
        {
            SFX_Slider.value = SFX_SliderVolume;
        }
        if (allSound.value != allAudioSliderVolume)
        {
            allSound.value = allAudioSliderVolume;
        }
        if (musicSlider.value != musicSliderVolume)
        {
            musicSlider.value = musicSliderVolume;
        }

    }

    public void VolumeUpdate()
    {
        allAudioSliderVolume = allSound.value;
        musicSliderVolume = musicSlider.value;
        SFX_SliderVolume = SFX_Slider.value;
        Debug.Log(allAudioSliderVolume);
        Debug.Log(musicSliderVolume);
        Debug.Log(SFX_SliderVolume);
    }
    private void Update()
    {
        allAudioSliderVolumeStatic = allAudioSliderVolume;
        musicSliderVolumeStatic = musicSliderVolume;
        SFX_SliderVolumeStatic = SFX_SliderVolume;
    }
}