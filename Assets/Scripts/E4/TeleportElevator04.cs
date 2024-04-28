using UnityEngine;

public class TeleportElevator04 : MonoBehaviour
{
    public Transform fakeCorridor; 
    public Transform realCorridor; 
    public GameObject player; 
    private CharacterController controller; // CharacterController 

    private void Start()
    {
        // CharacterController 
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

        // CharacterController
        controller.enabled = false;

        //
        player.transform.position = newPlayerPosition;
        player.transform.rotation = newPlayerRotation;

        // CharacterController
        controller.enabled = true;

        Debug.Log("Teleported to new position: " + player.transform.position);
    }
}

