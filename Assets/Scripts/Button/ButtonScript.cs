using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent PressButton;
    public UnityEvent OneSecondCommand;

    public bool isTriggered;
    public bool isDoorOpened;

    public bool isMultipleButton;

    public float waitTime = 1f;


    private void OnMouseUpAsButton()
    {
        if(isMultipleButton)
        {
            //isDoorOpened = true;
            PressButton.Invoke();
            StartCoroutine(WaitOneSecondandDo());
        }
        else
        {
            if (!isTriggered && !isDoorOpened)
            {
                isDoorOpened = true;
                PressButton.Invoke();
                StartCoroutine(WaitOneSecondandDo());
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
