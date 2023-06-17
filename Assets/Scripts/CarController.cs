using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    public WheelCollider[] wheel_col;
    public Transform[] wheels;
    float torque = 400;
    float angle = 45;

    public GameObject MainCanvas;
    public GameObject[] packagesFrom;
    public GameObject[] packagesInto;
    public bool leftButtonPressed = false;
    public bool rightButtonPressed = false;
    public bool gasButtonPressed = false;
    public bool breakButtonPressed = false;

    void Update()
    {
        for (int i = 0; i < wheel_col.Length; i++)
        {
            if (gasButtonPressed)
            {
                wheel_col[i].motorTorque = 1 * torque;
            }
            else
            {
                wheel_col[i].motorTorque = 0;
            }
            //wheel_col[i].motorTorque = Input.GetAxis("Vertical") * torque;
            if (i == 0 || i == 1)
            {
                if (leftButtonPressed)
                {
                    wheel_col[i].steerAngle = -1 * angle;
                }
                if (rightButtonPressed)
                {
                    wheel_col[i].steerAngle = angle;
                }

                if (!(leftButtonPressed || rightButtonPressed))
                {
                    wheel_col[i].steerAngle = 0;
                }
                //wheel_col[i].steerAngle = Input.GetAxis("Horizontal") * angle;
            }

            var pos = transform.position;
            var rot = transform.rotation;
            wheel_col[i].GetWorldPose(out pos, out rot);
            wheels[i].position = pos;
            wheels[i].rotation = rot;
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space) || breakButtonPressed)
            {
                foreach (var i in wheel_col)
                {
                    i.brakeTorque = 2000;
                }
            }
            else
            {
                //reset the brake torque when another key is pressed
                foreach (var i in wheel_col)
                {
                    i.brakeTorque = 0;
                }

            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!MainCanvas.GetComponent<Main>().hasTask)
        {
            return;
        }
        
        if (!MainCanvas.GetComponent<Main>().isPackageTaken)
        {
            if (other.gameObject.name.Contains("Package"))
            {
                MainCanvas.GetComponent<Main>().isPackageTaken = true;
                MainCanvas.GetComponent<Main>().Packages[MainCanvas.GetComponent<Main>().task].SetActive(false);
                ActivateCheckpoint();
                //take package 3d object
            }
        }

        if (other.gameObject == packagesInto[MainCanvas.GetComponent<Main>().task] && MainCanvas.GetComponent<Main>().isPackageTaken)
        {
            packagesInto[MainCanvas.GetComponent<Main>().task].SetActive(false);
            MainCanvas.GetComponent<Main>().ShowReward();
            MainCanvas.GetComponent<Main>().isPackageTaken = false;
        }
    }

    private void ActivateCheckpoint()
    {
        for (int i = 0; i < packagesInto.Length; i++)
        {
            packagesInto[i].SetActive(false);
        }
        packagesInto[MainCanvas.GetComponent<Main>().task].SetActive(true);
    }

    
}
