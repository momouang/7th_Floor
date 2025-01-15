using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpider : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Destroying());
    }

    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(5);

        DeleteSpider();
    }

    private void DeleteSpider()
    {
        Destroy(gameObject);
    }
}
