using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class E0ButtonScript : MonoBehaviour
{
    public DoorScript Door01;
    public DoorScript Door02;

    public UnityEvent PressButton;
    public UnityEvent OneSecondCommand;
    public UnityEvent OnlastTimeDoorOpened;
    public int OpenCount = 0;

    public bool isPressed;
    public bool isTriggered;

    public float waitTime = 1f;

    private void OnMouseUpAsButton()
    {
        if(!isTriggered && Door01.isControllable && Door02.isClosed)
        {
            PressButton.Invoke();
            StartCoroutine(WaitOneSecondandDo());
            OpenCount++;
            isPressed = true;

            if(OpenCount >= 3)
            {
                StartCoroutine(OpenDoor());
                isTriggered = true;
            }
        }
    }

    IEnumerator WaitOneSecondandDo()
    {
        yield return new WaitForSeconds(waitTime);
        OneSecondCommand.Invoke();
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(waitTime);
        OnlastTimeDoorOpened.Invoke();
    }
}
