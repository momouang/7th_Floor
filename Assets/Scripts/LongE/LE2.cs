using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LE2 : MonoBehaviour
{
    public Transform player; // ��ҵ�Transform���
    public Transform object1; // ��Ϸ�е�����1
    public Transform object2; // ��Ϸ�е�����2
    private float lastXPosition; // ��һ֡��ҵ�X����
    private bool isCollidingWithCollider1 = false;
    private bool isCollidingWithCollider2 = false;
    private bool isCollidingWithCollider3 = false;
    private bool isCollidingWithCollider4 = false;

    private bool oknow = false;
    void Start()
    {
        // ��ʼ��ʱ��¼��ҵĵ�ǰX����
        lastXPosition = player.position.x;
    }

    void Update()
    {
        if (!oknow)
        {
            // ������X����仯
            float currentPlayerX = player.position.x;
            if (currentPlayerX < lastXPosition && isCollidingWithCollider1)
            {
                // �ƶ�����2��X�ᵽ����1��X-50������
                object2.position = new Vector3(object1.position.x - 45.36f, object2.position.y, object2.position.z);
            }
            else if (currentPlayerX > lastXPosition && isCollidingWithCollider2)
            {
                // �ƶ�����2��X�ᵽ����1��X+50������
                object2.position = new Vector3(object1.position.x + 45.36f, object2.position.y, object2.position.z);
            }

            if (currentPlayerX < lastXPosition && isCollidingWithCollider3)
            {
                // �ƶ�����2��X�ᵽ����1��X-50������
                object1.position = new Vector3(object2.position.x - 45.36f, object1.position.y, object1.position.z);
            }
            else if (currentPlayerX > lastXPosition && isCollidingWithCollider4)
            {
                // �ƶ�����2��X�ᵽ����1��X+50������
                object1.position = new Vector3(object2.position.x + 45.36f, object1.position.y, object1.position.z);
            }

            // ������һ֡��X����ֵ
            lastXPosition = currentPlayerX;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Collider1")
        {
            isCollidingWithCollider1 = true;
        }
        if (other.gameObject.name == "Collider2")
        {
            isCollidingWithCollider2 = true;
        }

        if (other.gameObject.name == "Collider3")
        {
            isCollidingWithCollider3 = true;
        }
        if (other.gameObject.name == "Collider4")
        {
            isCollidingWithCollider4 = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Collider1")
        {
            isCollidingWithCollider1 = false;
        }

        if (other.gameObject.name == "Collider2")
        {
            isCollidingWithCollider2 = false;
        }

        if (other.gameObject.name == "Collider3")
        {
            isCollidingWithCollider3 = false;
        }
        if (other.gameObject.name == "Collider4")
        {
            isCollidingWithCollider4 = false;
        }
    }

    public void Oknnow()
    {
        oknow = true;
    }

}
