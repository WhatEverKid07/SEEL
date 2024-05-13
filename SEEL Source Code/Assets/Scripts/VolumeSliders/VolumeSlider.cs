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

    [Header("Starting Value")]
    public  float allAudioSliderVolume;
    public  float musicSliderVolume;
    public  float SFX_SliderVolume;
    public  float dialogueVolume;
    [Space]
    [Space]

    public AudioMixer musicMixer;

    public bool isGameScene;

    private void Start()
    {
        if (!isGameScene)
        {
            allSound.value = allAudioSliderVolume;
            musicSlider.value = musicSliderVolume;
            SFX_Slider.value = SFX_SliderVolume;
            dialogueSlider.value = dialogueVolume;
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
    }
}