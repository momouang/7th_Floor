using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;

    public float speed = 12f;
    public float runSpeed = 18f;
    public float gravity = -9.8f;
    public float startDelayTime = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    public AudioSource footStep;
    public AudioClip clipWalk, clipRun;
    public bool isPlayedFootstep;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool isPlayerCanMove = true;
    public Animator anim;

    private bool isRunning = false;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isRunning = (Input.GetKey(KeyCode.LeftShift));
        if (Input.GetKeyDown(KeyCode.LeftShift))
            SetRunning(true);
        if (Input.GetKeyUp(KeyCode.LeftShift))
            SetRunning(false);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isPlayerCanMove)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            RBMove(x,z);
            //CCMove(x,z);

            if (new Vector2(x,z).magnitude >= 0.1 && !isPlayedFootstep)
            {
                footStep.Play();
                isPlayedFootstep = true;
            }

            if (new Vector2(x, z).magnitude < 0.01 && isPlayedFootstep)
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

    private void FixedUpdate()
    {
        
    }

    private void CCMove(float x,float z)
    {
        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void RBMove(float x, float z)
    {
        float finalSpeed = (isRunning) ? runSpeed : speed;
        Vector3 move = (transform.right * x + transform.forward * z) * finalSpeed;
        rb.velocity = new Vector3(move.x,rb.velocity.y,move.z);
    }

    private void SetRunning(bool state)
    {
        bool currentState = isRunning;
        isRunning = state;

        footStep.clip = (isRunning) ? clipRun : clipWalk;

        footStep.Play();
        if (currentState != isRunning)
        {
            Debug.Log("State");
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

