using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent PressButton;
    public UnityEvent OneSecondCommand;
    public UnityEvent OneThirdCommand;

    public bool Reopenable = false;

    public bool isTriggered;
    public bool isDoorOpened;

    public bool isMultipleButton;
    public bool isNo8Elevator;

    public float waitTime = 1f;

    public IsEnteredElevator isEnteredElevator;
    private bool canPressButton = true;
    private void OnMouseUpAsButton()
    {
        if(isMultipleButton && !isNo8Elevator)
        {
            //isDoorOpened = true;
            PressButton.Invoke();
            StartCoroutine(WaitOneSecondandDo());
        }
        else if(isNo8Elevator){
            if(canPressButton){
                canPressButton = false;
                PressButton.Invoke();
            }
            StartCoroutine(WaitOneSecondandDo());
            if(isEnteredElevator.isEntered){
                canPressButton = true;
            }
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

        yield return new WaitForSeconds(3f);
        OneThirdCommand.Invoke();


        if (Reopenable)
        {
            isDoorOpened = false;
            isTriggered = false;
        }
    }
}
