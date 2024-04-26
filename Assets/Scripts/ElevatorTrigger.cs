using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorTrigger : MonoBehaviour
{
    public UnityEvent OnTriggered;
    public UnityEvent OnDelayed;
    public bool isTriggered = false;

    public float waitTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!isTriggered)
            {
                OnTriggered?.Invoke();
                StartCoroutine(OnDelay());
                isTriggered = true;

            }
        }
    }

    IEnumerator OnDelay()
    {
        yield return new WaitForSeconds(waitTime);
        OnDelayed.Invoke();
    }
}
