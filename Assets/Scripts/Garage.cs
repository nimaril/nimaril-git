using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Garage : MonoBehaviour
{
    public Material[] mats;
    public GameObject car;

    public void Start()
    {
        int carColor = PlayerPrefs.GetInt("CarColor", 0);
        ChangeColor(carColor);
    }
    
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeColor(int color)
    {
        car.GetComponent<MeshRenderer>().material = mats[color];
        PlayerPrefs.SetInt("CarColor", color);
        PlayerPrefs.Save();
    }
}
