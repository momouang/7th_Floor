using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public AudioSource footStep;
    public bool isPlayedFootstep;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(move.magnitude >=0.1 && !isPlayedFootstep)
        {
            footStep.Play();
            isPlayedFootstep = true;
        }

        if(move.magnitude < 0.01 && isPlayedFootstep)
        {
            footStep.Stop();
            isPlayedFootstep = false;
        }

    }
}
