using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    public Transform Button7;
    public bool RandomizeOnAwake = false;
    public bool PreviewPosition = true;
    public float PreviewSize = .07f;
    public List<Transform> ButtonPositions = new List<Transform>();

    private void Awake()
    {
        if (RandomizeOnAwake)
            RandomizePosition();
    }

    public void RandomizePosition()
    {
        int rndIndex = Random.Range(0, ButtonPositions.Count);
        Button7.SetPositionAndRotation(ButtonPositions[rndIndex].position, ButtonPositions[rndIndex].rotation);
    }

    private void OnDrawGizmos()
    {
        if (PreviewPosition)
            Gizmos.color = Color.yellow;
            foreach (Transform t in ButtonPositions)
                Gizmos.DrawSphere(t.position, PreviewSize);
    }
}
