using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class E0ButtonScript : MonoBehaviour
{
    [Header("Button Events")]
    public DoorScript Door01;
    public DoorScript Door02;

    public UnityEvent PressButton;
    public UnityEvent OneSecondCommand;
    public UnityEvent OnlastTimeDoorOpened;
    public int OpenCount = 0;

    public bool isPressed;
    public bool isTriggered;

    public float waitTime = 1f;

    [Header("Trigger Objects")]
    public GameObject BrokenLevel;
    public GameObject BrokenLevel02;
    public GameObject E1;

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

        if (OpenCount == 1)
        {
            StartCoroutine(ChangeBrokenLevel());
        }

        if (OpenCount == 2)
        {
            StartCoroutine(ChangeBrokenLevel02());
        }

        if(OpenCount == 3)
        {
            StartCoroutine(SetActiveElevator());
            Door02.isDoorNeedClose = false;
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

    IEnumerator ChangeBrokenLevel()
    {
        yield return new WaitForSeconds(2f);
        BrokenLevel02.SetActive(false); 
    }

    IEnumerator ChangeBrokenLevel02()
    {
        yield return new WaitForSeconds(2f);
        BrokenLevel.SetActive(false);
        BrokenLevel02.SetActive(true);
    }

    IEnumerator SetActiveElevator()
    {
        yield return new WaitForSeconds(2f);
        
        BrokenLevel02.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //E1.SetActive(true);
    }
}
