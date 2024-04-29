using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorTrigger : MonoBehaviour
{
    public UnityEvent OnTriggered;
    public UnityEvent OnDelayed;
    public bool isTriggered = false;
    public bool is08Button;

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
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && is08Button)
        {
            if(isTriggered)
            {
                isTriggered = false;
            }
        }
    }

    IEnumerator OnDelay()
    {
        yield return new WaitForSeconds(waitTime);
        OnDelayed.Invoke();
    }
}
