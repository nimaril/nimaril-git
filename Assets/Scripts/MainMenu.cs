using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool isMute = false;

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
        //
    }
    
    public void Mute (){
         isMute = ! isMute;
         AudioListener.volume =  isMute ? 0 : 1;
         Debug.Log(AudioListener.volume);
    }
}
