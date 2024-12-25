using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EscaltorSimple : MonoBehaviour
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

    private void Start()
    {
        var collider = GetComponent<BoxCollider>();
        _length = Mathf.Max(Mathf.Max(collider.size.x * transform.lossyScale.x, collider.size.y * transform.lossyScale.y), collider.size.z * transform.lossyScale.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        var rigidBody = other.GetComponent<Rigidbody>();
        if (rigidBody != null && rigidBody.isKinematic && !_characters.Contains(other.gameObject))
        {
            _characters.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_characters.Contains(other.gameObject))
        {
            _characters.Remove(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        foreach (var go in _characters)
        {
            var v = _goesDown ? Vector3.left : Vector3.right;
            var t = _travelTime != 0f ? _travelTime : DEFAULT_TRAVEL_TIME;
            var move = (transform.rotation * v * Time.fixedDeltaTime * (_length / t));
            go.transform.position += move;
        }
    }
}
