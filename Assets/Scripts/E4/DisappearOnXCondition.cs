using UnityEngine;

public class DisappearOnXCondition : MonoBehaviour
{
    public Transform referenceObject; // 参考物体
    public Transform[] objectsToCompare; // 需要比较的物体数组

    public bool okok = false;

    void Update()
    {
        float referenceX = referenceObject.position.x; // 获取参考物体的X轴世界坐标

        // 遍历所有要比较的物体
        foreach (var obj in objectsToCompare)
        {
            // 检查每个物体的X轴世界坐标是否大于参考物体的X轴坐标
            if ((obj.position.x > referenceX) && (okok))
            {
                obj.gameObject.SetActive(false); // 如果是，就隐藏该物体
            }
        }
    }

    public void Oknow()
    {
        okok = true;
    }
}