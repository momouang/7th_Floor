using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorTrigger : MonoBehaviour
{
    public UnityEvent OnTriggered;
    public bool isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!isTriggered)
            {
                OnTriggered?.Invoke();
                isTriggered = true;
            }
        }
    }
}
