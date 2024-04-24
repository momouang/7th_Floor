using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class E0ButtonScript : MonoBehaviour
{
    public static Action OnDoorClosed;

    public UnityEvent PressButton;
    public UnityEvent PressCloseButton;
    public UnityEvent OneSecondCommand;
    public int OpenCount = 0;

    public bool isTriggered;

    public float waitTime = 1f;

    private void OnMouseUpAsButton()
    {

        if(!isTriggered)
        {
            PressButton.Invoke();
            StartCoroutine(WaitOneSecondandDo());
            OpenCount++;

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
