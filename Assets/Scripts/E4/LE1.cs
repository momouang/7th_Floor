using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LE1 : MonoBehaviour
{
    public Transform player; // ��ҵ�Transform���
    private float offsetX; // ���������֮��ĳ�ʼ���X�����
    private float maxPlayerX; // ������¼��ҵ�X�����λ��

    public Collider triggerCollider;

    private bool hasTriggered = false;

    public bool doorok = false;

    public bool okok = false;

    void Start()
    {

    }

    void Update()
    {
        if (!hasTriggered && triggerCollider.bounds.Contains(player.position))
        {
            okok = true;
            offsetX = transform.position.x - player.position.x;
            // ��ʼ��maxPlayerXΪ��ǰ��ҵ�X��λ��
            maxPlayerX = player.position.x;
            hasTriggered = true;  // ���ñ�־Ϊtrue����ʾ�¼��Ѵ���
        }

        if ((!doorok) && (okok))
        {
            // ������ҵ�X�����λ��
            if (player.position.x > maxPlayerX)
            {
                maxPlayerX = player.position.x;
            }

            // �����X��λ�ø���Ϊ��ҵ�X�����λ�ü��ϳ�ʼ��Ծ���
            transform.position = new Vector3(maxPlayerX + offsetX, transform.position.y, transform.position.z);
        }
    }

    public void dooroknow()
    {
        doorok = true;
    }
}
