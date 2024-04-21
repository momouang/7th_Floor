using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisibilityController : MonoBehaviour
{
    public Camera playerCamera; // 玩家相机
    public GameObject[] parentWalls; // 要控制可见性的墙数组
    public GameObject[] controlledWalls; // 控制可见性后对应的墙数组
    private float[] lookTimes; // 对应墙被看到的累积时间

    public Transform player;   // 玩家的Transform引用
    public Collider triggerCollider;  // 触发器的Collider引用
    private bool hasTriggered = false;
    private bool okok = false;

    private Plane[] cameraPlanes;
    private bool[] hasBeenSeenEnough; // 是否已经达到观察足够时间的标记

    private void Start()
    {
        // 初始化数组和时间
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
            hasTriggered = true;  // 设置标志为true，表示事件已触发
        }

        for (int i = 0; i < parentWalls.Length; i++)
        {
            bool isVisible = IsObjectVisible(parentWalls[i]);

            if (okok ==true)
            {
                

                // 累积看向墙体的时间
                if (isVisible)
                {
                    lookTimes[i] += Time.deltaTime;
                    // 标记墙体已经被看足够长时间
                    if (lookTimes[i] >= 3)
                    {
                        hasBeenSeenEnough[i] = true;
                    }
                }

                // 检查是否已观察足够长时间且当前不可见
                if (hasBeenSeenEnough[i] && !isVisible)
                {
                    controlledWalls[i].SetActive(false); // 隐藏墙体
                    hasBeenSeenEnough[i] = false; // 重置观察标记，防止后续错误触发
                    lookTimes[i] = 0; // 重置观察时间，以备后续可能的逻辑使用
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