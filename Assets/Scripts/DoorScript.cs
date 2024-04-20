using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetTrigger("isOpened");

    }

    public void CloseDoor()
    {
        animator.SetTrigger("isClosed");
        //StartCoroutine(Closing());
    }

    /*IEnumerator Closing()
    {
        yield return new WaitForSeconds(5f);

        animator.SetTrigger("isClosed");

    }*/
}
