using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class E0ButtonScript : MonoBehaviour
{
    public DoorScript Door;

    public UnityEvent PressButton;
    public UnityEvent OneSecondCommand;
    public int OpenCount = 0;

    public bool isPressed;
    public bool isTriggered;

    public float waitTime = 1f;

    private void OnMouseUpAsButton()
    {
        if(!isTriggered && Door.isControllable)
        {
            PressButton.Invoke();
            StartCoroutine(WaitOneSecondandDo());
            OpenCount++;
            isPressed = true;

            if(OpenCount >= 3)
            {
                isTriggered = true;
            }
        }
    }

    IEnumerator WaitOneSecondandDo()
    {
        yield return new WaitForSeconds(waitTime);
        OneSecondCommand.Invoke();
    }
}
