using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LE2 : MonoBehaviour
{
    public Transform player; // ��ҵ�Transform���
    public Transform object1;
    public GameObject object11;// ��Ϸ�е�����1
    public Transform object2; // ��Ϸ�е�����2
    private float lastXPosition; // ��һ֡��ҵ�X����
    private bool isCollidingWithCollider1 = false;
    private bool isCollidingWithCollider2 = false;
    private bool test1= false;
    private bool test2 = true;

    public GameObject lightGameObject;

    private Light[] lightComponents;

    private bool oknow = false;
    void Start()
    {
        // ��ʼ��ʱ��¼��ҵĵ�ǰX����
        lastXPosition = player.position.x;
        //lightComponents = lightGameObject.GetComponentsInChildren<Light>();
    }

    void Update()
    {
        if (!oknow)
        {
            // ������X����仯

            if (isCollidingWithCollider1 && test1)
            {
                float targetX = object1.position.x + 84.24f;
                Debug.Log($"Moving Object2 to X: {targetX}");
                object2.position = new Vector3(targetX, object2.position.y, object2.position.z);
            }

            if (isCollidingWithCollider2 && test2)
            {
                float targetX = object2.position.x + 84.24f;
                Debug.Log($"Moving Object1 to X: {targetX}");
                object1.position = new Vector3(targetX, object1.position.y, object1.position.z);
                test1 = true;
            }

            // ������һ֡��X����ֵ
        }
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Collider1ee")
        {
            isCollidingWithCollider1 = true;
        }

        if (other.gameObject.name == "Collider2ee")
        {
            isCollidingWithCollider2 = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "Collider1ee")
        {
            isCollidingWithCollider1 = false;
        }

        if (other.gameObject.name == "Collider2ee")
        {
            isCollidingWithCollider2 = false;
        }
    }

    public void Oknnow()
    {
        oknow = true;
        if (lightComponents != null)
        {
            foreach (Light light in lightComponents)
            {
                light.enabled = false;
            }
        }
        object11.SetActive(false);
    }

}
