using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScene;
    public GameObject Player;
    public Transform transitPoint;

    public static bool isPaused;

    public bool DebugMode = false;


    private void Update()
    {
        if (DebugMode)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        CheckPause(isPaused);

    }

    private void CheckPause(bool _isPause)
    {
        if (_isPause)
        {

            pauseScene.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;

            AudioListener.pause = true;

        }
        else
        {
            pauseScene.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;

            AudioListener.pause = false;
        }
    }

    public void Continue()
    {
        isPaused = false;
    }

    public void Retry()
    {
        isPaused = false;
        //StartCoroutine(TransitPlayer());
        SceneManager.LoadScene(0);
        StartCameraMove.isPlayerControllable = false;

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void MouseControl()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator TransitPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        Player.transform.position = transitPoint.position;
    }
}
