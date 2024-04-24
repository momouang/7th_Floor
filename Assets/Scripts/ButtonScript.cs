using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ButtonScript : MonoBehaviour
{
    public static Action OnDoorOpened;

    public UnityEvent PressButton;
    public UnityEvent OneSecondCommand;
    public bool isCloseButton;

    public bool isTriggered;
    public bool isDoorOpened;

    public float waitTime = 1f;

    private void OnEnable()
    {
        E0ButtonScript.OnDoorClosed += SayDoorClosed;
    }

    private void OnDisable()
    {
        E0ButtonScript.OnDoorClosed -= SayDoorClosed;
    }

    private void OnMouseUpAsButton()
    {
        if(!isTriggered && !isDoorOpened)
        {
            isDoorOpened = true;
            OnDoorOpened?.Invoke();
            PressButton.Invoke();
            StartCoroutine(WaitOneSecondandDo());
            isTriggered = true;
        }
    }

    public void SayDoorClosed()
    {
        isDoorOpened = false;
    }

    IEnumerator WaitOneSecondandDo()
    {
        yield return new WaitForSeconds(waitTime);
        OneSecondCommand.Invoke();
    }
}
