using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LE1 : MonoBehaviour
{
    public Transform player; // 玩家的Transform组件
    private float offsetX; // 物体与玩家之间的初始相对X轴距离
    private float maxPlayerX; // 用来记录玩家的X轴最大位置

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
            // 初始化maxPlayerX为当前玩家的X轴位置
            maxPlayerX = player.position.x;
            hasTriggered = true;  // 设置标志为true，表示事件已触发
        }

        if ((!doorok) && (okok))
        {
            // 更新玩家的X轴最大位置
            if (player.position.x > maxPlayerX)
            {
                maxPlayerX = player.position.x;
            }

            // 物体的X轴位置更新为玩家的X轴最大位置加上初始相对距离
            transform.position = new Vector3(maxPlayerX + offsetX, transform.position.y, transform.position.z);
        }
    }

    public void dooroknow()
    {
        doorok = true;
    }
}
