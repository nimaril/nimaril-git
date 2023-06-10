using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Garage : MonoBehaviour
{
    public Material[] mats;
    public GameObject car;
    public GameObject moneyGO;
    public int[] colorsCosts = { 100, 100, 100, 100, 100, 100, 100, 100 };
    public float musicVolume;

    public void Start()
    {
        int carColor = PlayerPrefs.GetInt("CarColor", 0);
        ChangeColor(carColor);
        
        int money = PlayerPrefs.GetInt("Money", 0);
        moneyGO.GetComponent<TMP_Text>().text = money.ToString();
        
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
        AudioListener.volume =  musicVolume;
    }
    
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeColor(int color)
    {
        /*
         
        unlocked??
        if (unlocked)
        {
            //change color
        }
        
        */
        car.GetComponent<MeshRenderer>().material = mats[color];
        PlayerPrefs.SetInt("CarColor", color);
        PlayerPrefs.Save();
    }
}
