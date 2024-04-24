using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloseButton : MonoBehaviour
{
    public UnityEvent OnDoorClosed;

    public int openCount = 0;
    public bool isDoorOpened;

    private void OnEnable()
    {
        ButtonScript.OnDoorOpened += SayDoorOpen;
    }

    private void OnDisable()
    {
        ButtonScript.OnDoorOpened -= SayDoorOpen;
    }

    private void OnMouseUpAsButton()
    {
        if(isDoorOpened)
        {
            OnDoorClosed.Invoke();
        }
    }

    public void SayDoorOpen()
    {
        isDoorOpened = true;
    }

}
