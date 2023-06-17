using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MyCarSound : MonoBehaviour
{
    AudioSource audioSource;
    public float minPitch = 0.05f;
    private float pitchFromCar;
     
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
    }
 
    // Update is called once per frame
    void Update()
    {
        pitchFromCar = gameObject.GetComponent<CarController>().wheel_col[0].motorTorque / 400;
        if(pitchFromCar < minPitch)
            audioSource.pitch = minPitch;
        else
            audioSource.pitch = pitchFromCar;
    }
}