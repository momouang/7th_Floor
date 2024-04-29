using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LE2 : MonoBehaviour
{
    public Transform player; // 玩家的Transform组件
    public Transform object1;
    public GameObject object11;// 游戏中的物体1
    public Transform object2; // 游戏中的物体2
    private float lastXPosition; // 上一帧玩家的X坐标
    private bool isCollidingWithCollider1 = false;
    private bool isCollidingWithCollider2 = false;
    private bool test1= false;
    private bool test2 = true;

    public GameObject lightGameObject;

    private Light[] lightComponents;

    private bool oknow = false;
    void Start()
    {
        // 初始化时记录玩家的当前X坐标
        lastXPosition = player.position.x;
        lightComponents = lightGameObject.GetComponentsInChildren<Light>();
    }

    void Update()
    {
        if (!oknow)
        {
            // 检测玩家X坐标变化

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

            // 更新上一帧的X坐标值
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
