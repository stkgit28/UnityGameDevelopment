using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public DataManager dataManager;
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float _sliderValue;

    public void Start()
    {
        if (dataManager.Data.Volume != 0.0f)
        {
            volumeSlider.value = dataManager.Data.Volume;
            mixer.SetFloat("MusicVol", Mathf.Log10(dataManager.Data.Volume)*20);
        }

    }
    public void SetLevel()
    {
        _sliderValue = volumeSlider.value;
        mixer.SetFloat("MusicVol", Mathf.Log10(_sliderValue)*20);
        dataManager.Data.Volume = _sliderValue;
        dataManager.Save();
    }
    
}
