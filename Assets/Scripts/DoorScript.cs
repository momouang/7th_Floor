using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;

    public bool isOpened;
    public bool isClosed;
    public bool isControllable;

    public bool isDoorNeedClose;
    public AudioSource CloseDoorSound;

    public ElevatorTrigger elevatorTrigger;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetTrigger("isOpened");
        isOpened = true;
        isClosed = false;
        isControllable = false;

        if(isDoorNeedClose && elevatorTrigger.isTriggered)
        {
            StartCoroutine(AutoCloseDoor());
        }

    }

    public void CloseDoor()
    {
        animator.SetTrigger("isClosed");
        isClosed = true;
        isOpened = false;
        isControllable = true;
        //StartCoroutine(Closing());
    }

    IEnumerator AutoCloseDoor()
    {
        yield return new WaitForSeconds(3f);
        CloseDoor();
        CloseDoorSound.Play();
    }


    /*IEnumerator Closing()
    {
        yield return new WaitForSeconds(5f);

        animator.SetTrigger("isClosed");

    }*/
}
