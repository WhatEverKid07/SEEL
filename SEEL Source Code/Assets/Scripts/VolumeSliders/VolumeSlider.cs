using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider allSound;
    public Slider musicSlider;
    public Slider SFX_Slider;



    private void Update()
    {
        AudioManager.globalVolume = allSound.value;
        AudioManager.musicVolume = musicSlider.value;
        AudioManager.SFX_Volume = SFX_Slider.value;
    }
}