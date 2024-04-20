using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent PressButton;
    public UnityEvent OneSecondCommand;

    public float waitTime = 1f;

    private void OnMouseUpAsButton()
    {
        PressButton.Invoke();
        StartCoroutine(WaitOneSecondandDo());
    }

    IEnumerator WaitOneSecondandDo()
    {
        yield return new WaitForSeconds(waitTime);
        OneSecondCommand.Invoke();
    }
}
