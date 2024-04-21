using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisibilityController : MonoBehaviour
{
    public Camera playerCamera; // ������
    public GameObject[] parentWalls; // Ҫ���ƿɼ��Ե�ǽ����
    public GameObject[] controlledWalls; // ���ƿɼ��Ժ��Ӧ��ǽ����
    private float[] lookTimes; // ��Ӧǽ���������ۻ�ʱ��

    public Transform player;   // ��ҵ�Transform����
    public Collider triggerCollider;  // ��������Collider����
    private bool hasTriggered = false;
    private bool okok = false;

    private Plane[] cameraPlanes;
    private bool[] hasBeenSeenEnough; // �Ƿ��Ѿ��ﵽ�۲��㹻ʱ��ı��

    private void Start()
    {
        // ��ʼ�������ʱ��
        lookTimes = new float[parentWalls.Length];
        hasBeenSeenEnough = new bool[parentWalls.Length];
        cameraPlanes = GeometryUtility.CalculateFrustumPlanes(playerCamera);
    }

    void Update()
    {
        cameraPlanes = GeometryUtility.CalculateFrustumPlanes(playerCamera);

        if (!hasTriggered && triggerCollider.bounds.Contains(player.position))
        {
            Debug.Log("Player has entered the specified area.");
            okok = true;
            hasTriggered = true;  // ���ñ�־Ϊtrue����ʾ�¼��Ѵ���
        }

        for (int i = 0; i < parentWalls.Length; i++)
        {
            bool isVisible = IsObjectVisible(parentWalls[i]);

            if (okok ==true)
            {
                

                // �ۻ�����ǽ���ʱ��
                if (isVisible)
                {
                    lookTimes[i] += Time.deltaTime;
                    // ���ǽ���Ѿ������㹻��ʱ��
                    if (lookTimes[i] >= 3)
                    {
                        hasBeenSeenEnough[i] = true;
                    }
                }

                // ����Ƿ��ѹ۲��㹻��ʱ���ҵ�ǰ���ɼ�
                if (hasBeenSeenEnough[i] && !isVisible)
                {
                    controlledWalls[i].SetActive(false); // ����ǽ��
                    hasBeenSeenEnough[i] = false; // ���ù۲��ǣ���ֹ�������󴥷�
                    lookTimes[i] = 0; // ���ù۲�ʱ�䣬�Ա��������ܵ��߼�ʹ��
                }
            }

        }
    }

    bool IsObjectVisible(GameObject obj)
    {
        Collider collider = obj.GetComponent<Collider>();
        if (collider == null)
        {
            Debug.LogError("Collider component not found on object: " + obj.name);
            return false;
        }

        Bounds bounds = collider.bounds;
        return GeometryUtility.TestPlanesAABB(cameraPlanes, bounds);
    }
}