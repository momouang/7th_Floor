using System.Collections;
using UnityEngine;
using Cinemachine;

public class StartCameraMove : MonoBehaviour
{
    public CinemachineFreeLook GameCam;
    public CinemachineFreeLook PlayerCam;
    public CinemachineVirtualCamera StartUICam;
    public int gameCamPriority = 0; 
    public int PlayerCamPriority = 0; 
    public int startUICamPriority = 10; 
    public float fadeDuration = 3.5f;

    public AudioClip doorSound;
    private AudioSource audioSource;

    private bool isSwitching = false;

    public Animator DoorAnimation;

    public static bool isControllable = false;

    void Start()
    {
        GameCam.Priority = gameCamPriority;
        StartUICam.Priority = startUICamPriority;
        PlayerCam.Priority = PlayerCamPriority;
        //Time.timeScale = 0f;
        audioSource = gameObject.AddComponent<AudioSource>();
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
            GameCam.Priority = startUICamPriority;
            StartUICam.Priority = 0;
            yield return null; 
        }

        if (doorSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(doorSound);
            yield return new WaitForSeconds(fadeDuration); 
            GameCam.Priority = 0;
            PlayerCam.Priority = startUICamPriority ;

            isControllable = true;
        }
    }
}