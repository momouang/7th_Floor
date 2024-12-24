using System.Collections;
using UnityEngine;
using Cinemachine;

public class StartCameraMove : MonoBehaviour
{
    //public CinemachineFreeLook GameCam;
    public CinemachineVirtualCamera PlayerCam;
    public CinemachineVirtualCamera StartUICam;
    //public int gameCamPriority = 0; 
    public int PlayerCamPriority = 0; 
    public int startUICamPriority = 10; 
    public float fadeDuration = 3.5f;

    //public AudioClip doorSound;
    public AudioSource doorSound;

    private bool isSwitching = false;

    public Animator DoorAnimation;

    public static bool isPlayerControllable = false;

    public GameObject playerBody;
    public GameObject player;

    void Start()
    {
        //GameCam.Priority = gameCamPriority;
        StartUICam.Priority = startUICamPriority;
        PlayerCam.Priority = PlayerCamPriority;
        //Time.timeScale = 0f;
        playerBody.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown && !isSwitching)
        {
            SwitchCameras();
        }
    }

    public void SwitchCameras()
    {
        StartCoroutine(FadeOutStart());
        
    }

    private IEnumerator FadeOutStart()
    {
        //Time.timeScale = 1f;
        isSwitching = true;

        if (DoorAnimation != null)
        {
            DoorAnimation.SetTrigger("OpenDoor");
            //GameCam.Priority = startUICamPriority;
            StartUICam.Priority = 0;
            
            yield return null; 
        }

        if (doorSound != null)
        {
            doorSound.Play();
            yield return new WaitForSeconds(fadeDuration); 
            //GameCam.Priority = 0;
            PlayerCam.Priority = startUICamPriority ;

            isPlayerControllable = true;
            playerBody.SetActive(true);
        }
    }
}
