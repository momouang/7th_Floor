using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class ElevatorSimple : MonoBehaviour
{
    private const float DEFAULT_TRAVEL_TIME = 7f;

    [SerializeField]
    [Tooltip("The amount of time it takes to travel across the escalator in seconds.")]
    private float _travelTime = DEFAULT_TRAVEL_TIME;

    [SerializeField]
    [Tooltip("Should the escalator move downwards?")]
    private bool _goesDown;

    private float _length;
    private HashSet<GameObject> _characters = new HashSet<GameObject>();

    public Animator anim;

    private void Start()
    {
        var collider = GetComponent<BoxCollider>();
        _length = Mathf.Max(Mathf.Max(collider.size.x * transform.lossyScale.x, collider.size.y * transform.lossyScale.y), collider.size.z * transform.lossyScale.z);
    }

    private void OnTriggerEnter(Collider other)
    {      
        var rigidBody = other.GetComponent<Rigidbody>();
        Debug.Log("Good");
        if (rigidBody != null && !rigidBody.isKinematic && !_characters.Contains(other.gameObject))
        {
            _characters.Add(other.gameObject);
            Debug.Log("Yay");
        }
    }

    private void OnTriggerExit(Collider other)
    {      
        if (_characters.Contains(other.gameObject))
        {
            _characters.Remove(other.gameObject);
            Debug.Log("OOp");
        }
    }

    private void Update()
    {
        anim.SetFloat("Speed",(_length/_travelTime));
        if(_goesDown)
        {
            anim.SetFloat("Speed", -(_length / _travelTime));
        }
    }

    private void FixedUpdate()
    {
        foreach (var go in _characters)
        {
            Debug.Log("FixedUpdate");
            var v = _goesDown ? Vector3.left : Vector3.right;
            var t = _travelTime != 0f ? _travelTime : DEFAULT_TRAVEL_TIME;
            var move = (transform.rotation * v * Time.fixedDeltaTime * (_length / t));
            go.transform.position += move;
        }
    }

    public void SwitchUpwards()
    {
        _goesDown = false;
    }
}
