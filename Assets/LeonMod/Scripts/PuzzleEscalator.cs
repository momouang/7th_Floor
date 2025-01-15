using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEscalator : MonoBehaviour
{
    public AudioSource sfx;

    public EscalatorModded escalator;

    public float speedOverride = -.1f;

    public float breakTime = 5f;

    private float currentTime = 0f;

    public bool isSolved = false;

    [SerializeField]
    private bool isInTrigger = false;

    private bool isBreak = false;

    // if in trigger, speed up.
    private void Update()
    {
        if(isSolved)
        {
            speedOverride = 1f;
            escalator.MoveVelocity = speedOverride;
        }
        else
        {
            if (isInTrigger)
            {
                SpeedUp();
            }
            else
            {
                SpeedDown();
            }
        }

        sfx.pitch = Mathf.Abs(speedOverride);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if(player!=null)
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            isInTrigger = false;
        }
    }

    private void SpeedUp()
    {
        if (speedOverride > -2f)
            speedOverride -= Time.deltaTime;
        else
            speedOverride = -2f;

        escalator.MoveVelocity = speedOverride;

        if (currentTime < breakTime)
            currentTime += Time.deltaTime;
        else
            OnLimitBreak();
    }

    private void SpeedDown()
    {
        if (speedOverride < -.1f)
            speedOverride += Time.deltaTime;
        else
            speedOverride = -.1f;

        escalator.MoveVelocity = speedOverride;

        if (currentTime > 0)
            currentTime -= Time.deltaTime;
    }

    private void OnLimitBreak()
    {
        if (isBreak)
            return;

        isBreak = true;

        // Do your thing here.
        // ===================



        // ===================
    }
}
