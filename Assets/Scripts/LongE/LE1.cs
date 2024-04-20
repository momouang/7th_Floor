using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LE1 : MonoBehaviour
{
    public Transform player; // 玩家的Transform组件
    private float offsetX; // 物体与玩家之间的初始相对X轴距离

    public bool doorok = false;

    void Start()
    {
        // 计算并保存初始相对X轴距离
        offsetX = transform.position.x - player.position.x;
    }

    void Update()
    {
        // 更新物体的X轴位置，使其保持与玩家相同的相对X轴距离
        // Y轴和Z轴位置保持不变
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
