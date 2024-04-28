// using UnityEngine;

// public class TeleportController : MonoBehaviour
// {
//     public Transform fakeCorridor; 
//     public Transform realCorridor; 
//     public GameObject player; 
//     private CharacterController controller; // CharacterController 

//     private void Start()
//     {
//         // CharacterController 
//         controller = player.GetComponent<CharacterController>();
//         if (controller == null)
//         {
//             Debug.LogError("CharacterController component not found on the player object.");
//         }
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         Debug.Log("Trigger Entered by: " + other.name);
//         if (other.gameObject == player)
//         {
//             Debug.Log("Teleporting player");
//             TeleportPlayer();
//         }
//     }

//     void TeleportPlayer()
//     {
//         Vector3 playerRelativePosition = fakeCorridor.InverseTransformPoint(player.transform.position);
//         Quaternion playerRelativeRotation = Quaternion.Inverse(fakeCorridor.rotation) * player.transform.rotation;

//         Vector3 newPlayerPosition = realCorridor.TransformPoint(playerRelativePosition);
//         Quaternion newPlayerRotation = realCorridor.rotation * playerRelativeRotation;

//         // CharacterController
//         controller.enabled = false;

//         //
//         player.transform.position = newPlayerPosition;
//         player.transform.rotation = newPlayerRotation;

//         // CharacterController
//         controller.enabled = true;

//         Debug.Log("Teleported to new position: " + player.transform.position);
//     }
// }

using System.Collections;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Transform fakeCorridor;
    public Transform[] realCorridors; 
    public GameObject player; 
    private CharacterController controller; 
    public DoorScript DoorScript;
    public IsEnteredElevator IsEnteredElevator;
    public GameObject ElevatorTrigger;

    private void Start()
    {
        ElevatorTrigger.SetActive(false);
        controller = player.GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController component not found on the player object.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(DoorScript.isOpened);
        //Debug.Log(IsEnteredElevator.isEntered);
        if (other.gameObject == player)
        {
            //Debug.Log("Teleporting player");
            if(DoorScript.isOpened && IsEnteredElevator.isEntered){
                ElevatorTrigger.SetActive(true);
                StartCoroutine(TeleportPlayer());
                //TeleportPlayer();
                IsEnteredElevator.Reset();
                DoorScript.Reset();
            }else{
                StartCoroutine(Ondelay());
            }
        }
    }

    IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(0.05f);
        Transform selectedRealCorridor = realCorridors[Random.Range(0, realCorridors.Length)];

        Vector3 playerRelativePosition = fakeCorridor.InverseTransformPoint(player.transform.position);
        Quaternion playerRelativeRotation = Quaternion.Inverse(fakeCorridor.rotation) * player.transform.rotation;

        Vector3 newPlayerPosition = selectedRealCorridor.TransformPoint(playerRelativePosition);
        Quaternion newPlayerRotation = selectedRealCorridor.rotation * playerRelativeRotation;

        controller.enabled = false;

        player.transform.position = newPlayerPosition;
        player.transform.rotation = newPlayerRotation;

        controller.enabled = true;
        StartCoroutine(Ondelay());
    }

    IEnumerator Ondelay(){
        yield return new WaitForSeconds(2f);
        ElevatorTrigger.SetActive(false);
    }
}
