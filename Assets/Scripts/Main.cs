using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    bool isMute = false;
    
    public void LoadSettings()
    {
        SceneManager.LoadScene(3);
    }
    
    public void Mute (){
        isMute = ! isMute;
        AudioListener.volume =  isMute ? 0 : 1;
        Debug.Log(AudioListener.volume);
    }
}
