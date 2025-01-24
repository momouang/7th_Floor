using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyLookAt : MonoBehaviour
{
    public GameObject target;
    private Vector3 lookDirection;

    private void Start()
    {
        lookDirection = target.transform.position - transform.position;
    }

    public void FixedUpdate()
    {
        //lookDirection.y = 0;
        gameObject.transform.LookAt(target.transform.position);
    }
}
