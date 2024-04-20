using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LE1 : MonoBehaviour
{
    public Transform player; // ��ҵ�Transform���
    private float offsetX; // ���������֮��ĳ�ʼ���X�����

    public bool doorok = false;

    void Start()
    {
        // ���㲢�����ʼ���X�����
        offsetX = transform.position.x - player.position.x;
    }

    void Update()
    {
        // ���������X��λ�ã�ʹ�䱣���������ͬ�����X�����
        // Y���Z��λ�ñ��ֲ���
        if (doorok == false)
        {

            transform.position = new Vector3(player.position.x + offsetX, transform.position.y, transform.position.z);
        }
    }

    public void dooroknow()
    {
        doorok = true;
    }
}
