using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool isMute = false;
    public float musicVolume;

    public void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
        AudioListener.volume =  musicVolume;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadGarage()
    {
        SceneManager.LoadScene(2);
    }
    
    public void LoadSettings()
    {
        SceneManager.LoadScene(3);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    public void Mute (){
         isMute = ! isMute;
         AudioListener.volume =  isMute ? 0 : musicVolume;
         Debug.Log(AudioListener.volume);
    }
}
