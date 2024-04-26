using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloseButton : MonoBehaviour
{
    public UnityEvent Door1Closed;
    public UnityEvent Door2Closed;

    public int openCount = 0;
    public bool isDoorOpened;

    public E0ButtonScript SevenButton;
    public DoorScript Door1;
    public DoorScript Door2;

    public int closeCount;

    public GameObject BrokenLevel;
    public GameObject BrokenLevel02;
    public GameObject E1;

    private void OnMouseUpAsButton()
    {
        if(Door1.isOpened)
        {
            Door1Closed.Invoke();
        }

        if (Door2.isOpened && SevenButton.OpenCount < 3)
        {
            Door2Closed.Invoke();
            closeCount++;
        }

        if (closeCount == 1 && SevenButton.OpenCount < 3)
        {
            StartCoroutine(ChangeBrokenLevel());
        }

        if (closeCount == 2 && SevenButton.OpenCount < 3)
        {
            StartCoroutine(SetActiveElevator());
        }
    }

    IEnumerator ChangeBrokenLevel()
    {
        yield return new WaitForSeconds(2f);
        BrokenLevel.SetActive(false);
        BrokenLevel02.SetActive(true); ;
    }

    IEnumerator SetActiveElevator()
    {
        yield return new WaitForSeconds(2f);
        E1.SetActive(true);
        BrokenLevel02.SetActive(false);
    }

}
