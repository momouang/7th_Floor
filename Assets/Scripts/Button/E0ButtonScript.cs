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
    public GameObject BackBlocker;
    public GameObject E1;
    public GameObject Screen01;
    public GameObject Screen02;

    private bool isOperating = false;

    private void OnMouseUpAsButton()
    {
        if (isOperating)
            return;

        isOperating = true;
        StartCoroutine(CoolDownTime());

        if (OpenCount >= 2)
        {
            OpenCount = 2;
            isTriggered = true;
        }

        if (!isTriggered && Door01.isControllable && Door02.isClosed)
        {
            PressButton.Invoke();
            StartCoroutine(WaitOneSecondandDo());

        }

        if (!isTriggered && OpenCount == 0)
        {
            Debug.Log("F0");
            StartCoroutine(ChangeBrokenLevel());
        }

        if (!isTriggered && OpenCount == 2) // Deprycated.
        {
            Debug.Log("F2");
            StartCoroutine(CoolDownTime());
            StartCoroutine(ChangeBrokenLevel02());
            Screen01.GetComponent<MeshRenderer>().enabled = false;
            Screen02.GetComponent<MeshRenderer>().enabled = true;
        }

        if(!isTriggered && OpenCount == 1)
        {
            Debug.Log("F1");
            StartCoroutine(SetActiveElevator());
            StartCoroutine(OpenDoor());
            Door02.isDoorNeedClose = false;
        }

        OpenCount++;
        isPressed = true;
    }

    public void BlockBackward(float time) => StartCoroutine(BlockBackwardIE(time));

    IEnumerator BlockBackwardIE(float time)
    {
        yield return new WaitForSeconds(time);
        BackBlocker.SetActive(true);
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
        BrokenLevel.SetActive(false);
        BrokenLevel02.SetActive(false);
        yield return new WaitForSeconds(2f);
        
        BrokenLevel02.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //E1.SetActive(true);
    }

    IEnumerator CoolDownTime()
    {
        yield return new WaitForSeconds(8f);
        isOperating = false;
    }

}
