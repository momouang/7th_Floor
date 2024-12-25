using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalatorStand : MonoBehaviour
{
    private bool isStepped = false;
    private Transform currentStep;

    private void OnCollisionEnter(Collision collision)
    {
        if (isStepped)
            return;

        if(collision.gameObject.CompareTag("EscStep"))
        {
            isStepped = true;
            currentStep = collision.transform;
            transform.SetParent(currentStep);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform == currentStep)
        {
            transform.SetParent(null);
            currentStep = null;
            isStepped = false;
        }
    }


}
