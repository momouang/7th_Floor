using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Transform fakeCorridor; // 假走廊的参考点
    public Transform realCorridor; // 真走廊的参考点
    public GameObject player; // 玩家对象
    private CharacterController controller; // CharacterController 变量声明

    private void Start()
    {
        // 获取 CharacterController 组件
        controller = player.GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController component not found on the player object.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.name);
        if (other.gameObject == player)
        {
            Debug.Log("Teleporting player");
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        Vector3 playerRelativePosition = fakeCorridor.InverseTransformPoint(player.transform.position);
        Quaternion playerRelativeRotation = Quaternion.Inverse(fakeCorridor.rotation) * player.transform.rotation;

        Vector3 newPlayerPosition = realCorridor.TransformPoint(playerRelativePosition);
        Quaternion newPlayerRotation = realCorridor.rotation * playerRelativeRotation;

        // 禁用CharacterController
        controller.enabled = false;

        // 更新位置和旋转
        player.transform.position = newPlayerPosition;
        player.transform.rotation = newPlayerRotation;

        // 重新启用CharacterController
        controller.enabled = true;

        Debug.Log("Teleported to new position: " + player.transform.position);
    }


}