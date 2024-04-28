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


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
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

    }

    IEnumerator TransitPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        Player.transform.position = transitPoint.position;
    }
}
