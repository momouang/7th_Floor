using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float startDelayTime = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    public AudioSource footStep;
    public bool isPlayedFootstep;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool isPlayerCanMove = true;
    public Animator anim;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (StartCameraMove.isPlayerControllable && isPlayerCanMove)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;


            controller.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (move.magnitude >= 0.1 && !isPlayedFootstep)
            {
                footStep.Play();
                isPlayedFootstep = true;
            }

            if (move.magnitude < 0.01 && isPlayedFootstep)
            {
                footStep.Stop();
                isPlayedFootstep = false;
            }

            if(x != 0 || z != 0)
            {
                anim.SetFloat("isWalking", 1);
            }

            if (x == 0 && z == 0)
            {
                anim.SetFloat("isWalking", 0);
            }
        }


        if (GameManager.isPaused && !isPlayerCanMove)
        {
            footStep.Stop();
        }

    }

    public void IsInEnding()
    {
        isPlayerCanMove = false;
    }

    public void ReturnToLobby()
    {
        isPlayerCanMove = true;
    }
}

