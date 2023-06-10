using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject MusicSlider;
    public GameObject SoundSlider;
    public float musicVolume;
    public float soundVolume;

    public void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
        AudioListener.volume =  musicVolume;
        MusicSlider.GetComponent<Slider>().value = musicVolume;
    }

    public void Back()
    {
        SceneManager.LoadScene(0); // ????? куда
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void OnMusicValueChange()
    {
        musicVolume = MusicSlider.GetComponent<Slider>().value;
        AudioListener.volume =  musicVolume;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
    }
}
