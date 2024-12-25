using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalatorModded : MonoBehaviour
{
    public Animator anim;

    [Range(-1f, 1f)]
    public float MoveVelocity = 0f;

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", MoveVelocity);
    }
}
