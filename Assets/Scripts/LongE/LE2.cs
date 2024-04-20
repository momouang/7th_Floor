using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LE2 : MonoBehaviour
{
    public Transform player; // 玩家的Transform组件
    public Transform object1; // 游戏中的物体1
    public Transform object2; // 游戏中的物体2
    private float lastXPosition; // 上一帧玩家的X坐标
    private bool isCollidingWithCollider1 = false;
    private bool isCollidingWithCollider2 = false;
    private bool isCollidingWithCollider3 = false;
    private bool isCollidingWithCollider4 = false;

    private bool oknow = false;
    void Start()
    {
        // 初始化时记录玩家的当前X坐标
        lastXPosition = player.position.x;
    }

    void Update()
    {
        if (!oknow)
        {
            // 检测玩家X坐标变化
            float currentPlayerX = player.position.x;
            if (currentPlayerX < lastXPosition && isCollidingWithCollider1)
            {
                // 移动物体2的X轴到物体1的X-50的坐标
                object2.position = new Vector3(object1.position.x - 45.36f, object2.position.y, object2.position.z);
            }
            else if (currentPlayerX > lastXPosition && isCollidingWithCollider2)
            {
                // 移动物体2的X轴到物体1的X+50的坐标
                object2.position = new Vector3(object1.position.x + 45.36f, object2.position.y, object2.position.z);
            }

            if (currentPlayerX < lastXPosition && isCollidingWithCollider3)
            {
                // 移动物体2的X轴到物体1的X-50的坐标
                object1.position = new Vector3(object2.position.x - 45.36f, object1.position.y, object1.position.z);
            }
            else if (currentPlayerX > lastXPosition && isCollidingWithCollider4)
            {
                // 移动物体2的X轴到物体1的X+50的坐标
                object1.position = new Vector3(object2.position.x + 45.36f, object1.position.y, object1.position.z);
            }

            // 更新上一帧的X坐标值
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
