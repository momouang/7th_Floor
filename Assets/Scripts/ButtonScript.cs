using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent PressButton;
    public UnityEvent OneSecondCommand;

    public bool isTriggered;

    public float waitTime = 1f;

    private void OnMouseUpAsButton()
    {
        if(!isTriggered)
        {
            PressButton.Invoke();
            StartCoroutine(WaitOneSecondandDo());

            isTriggered = true;
        }
    }

    IEnumerator WaitOneSecondandDo()
    {
        yield return new WaitForSeconds(waitTime);
        OneSecondCommand.Invoke();
    }
}
