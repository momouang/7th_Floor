using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;

    public bool isOpened;
    public bool isClosed;
    public bool isControllable;


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

    }

    public void CloseDoor()
    {
        animator.SetTrigger("isClosed");
        isClosed = true;
        isOpened = false;
        isControllable = true;
        //StartCoroutine(Closing());
    }

    /*IEnumerator Closing()
    {
        yield return new WaitForSeconds(5f);

        animator.SetTrigger("isClosed");

    }*/
}
