using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Transform fakeCorridor; // �����ȵĲο���
    public Transform realCorridor; // �����ȵĲο���
    public GameObject player; // ��Ҷ���
    private CharacterController controller; // CharacterController ��������

    private void Start()
    {
        // ��ȡ CharacterController ���
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

        // ����CharacterController
        controller.enabled = false;

        // ����λ�ú���ת
        player.transform.position = newPlayerPosition;
        player.transform.rotation = newPlayerRotation;

        // ��������CharacterController
        controller.enabled = true;

        Debug.Log("Teleported to new position: " + player.transform.position);
    }


}