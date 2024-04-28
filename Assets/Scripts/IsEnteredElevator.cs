using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnteredElevator : MonoBehaviour
{
    public bool isEntered;
    //public GameObject player; 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Start");
        if (other.CompareTag("Player"))
        {
            isEntered = true;
            Debug.Log(isEntered);
        }
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = false;
        }
    }

    public void Reset()
    {
        isEntered = false;
    }

}
