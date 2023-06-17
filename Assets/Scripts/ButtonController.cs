using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int buttonID;
    public bool buttonPressed;
    public GameObject car;
 
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }
 
    public void OnPointerUp(PointerEventData eventData){
        buttonPressed = false;
    }

    void Update()
    {
        ButtonControll(buttonID);
    }

    public void ButtonControll(int button)
    {
        if (button == 0)
        {
            car.GetComponent<CarController>().leftButtonPressed = buttonPressed;
        }
        if (button == 1)
        {
            car.GetComponent<CarController>().rightButtonPressed = buttonPressed;
        }
        if (button == 2)
        {
            car.GetComponent<CarController>().gasButtonPressed = buttonPressed;
        }
        if (button == 3)
        {
            car.GetComponent<CarController>().breakButtonPressed = buttonPressed;
        }
    }
}