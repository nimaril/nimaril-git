using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    bool isMute = false;
    public Material[] mats;
    public GameObject car;

    public void Start()
    {
        int carColor = PlayerPrefs.GetInt("CarColor", 0);
        car.GetComponent<MeshRenderer>().material = mats[carColor];
    }
    
    public void LoadSettings()
    {
        SceneManager.LoadScene(3);
    }

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        Debug.Log(AudioListener.volume);
    }
}
