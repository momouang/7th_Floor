using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpider : MonoBehaviour
{

    public int destroyTime = 10;


    private void Start()
    {
        StartCoroutine(Destroying());
    }

    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(destroyTime);

        DeleteSpider();
    }

    private void DeleteSpider()
    {
        Destroy(gameObject);
    }
}
