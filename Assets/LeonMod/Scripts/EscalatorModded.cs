using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalatorModded : MonoBehaviour
{
    public Animator anim;

    [Range(-2f, 2f)]
    public float MoveVelocity = 0f;

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", MoveVelocity);
    }

    public void SpeedChanged()
    {
        MoveVelocity = 1;
        Debug.Log("speed");
    }
}
