using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NormalButton : MonoBehaviour
{
    public DoorScript Door1;
    public DoorScript Door2;
    public E0ButtonScript SevenButton;
    public UnityEvent SameFloor;
    public UnityEvent DifferentFloor;
    public UnityEvent OneSecondCommand;
    public float waitTime = 5f;

    public bool isTriggered;
    public bool isDoorOpened;



    private void OnMouseUpAsButton()
    {
        if(SevenButton.OpenCount <3)
        {
            if (Door1.isControllable && Door2.isClosed && !SevenButton.isPressed)
            {
                SameFloor.Invoke();
            }
            else if (Door1.isControllable && Door2.isClosed && SevenButton.isPressed)
            {
                DifferentFloor.Invoke();
                StartCoroutine(WaitOneSecondandDo());
            }
        }
    }

    IEnumerator WaitOneSecondandDo()
    {
        yield return new WaitForSeconds(waitTime);
        OneSecondCommand.Invoke();
    }
}
