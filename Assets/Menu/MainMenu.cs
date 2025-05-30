using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject levelUI;

    private Transform player;
    private Rigidbody playerRB;

    private Transform check1;
    private Transform check2;
    private Transform check3;


    void Start()
    {
        player = GameObject.Find("Player").transform;
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody>();

        check1 = GameObject.Find("CheckPoint01").transform;
        check2 = GameObject.Find("CheckPoint02").transform;
        check3 = GameObject.Find("CheckPoint03").transform;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        levelUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GamePaused = false;
        Time.timeScale = 1f;
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GamePaused = false;
        Time.timeScale = 1f;
    }

    public void SelectLevel1()
    {
        levelSelect(1);
    }

    public void SelectLevel2()
    {
        levelSelect(2);
    }

    public void SelectLevel3()
    {
        levelSelect(3);
    }

    public void levelSelect(int level)
    {
        switch (level)
        {
            case 1:
                player.transform.position = check1.position;
                break;
            case 2:
                player.transform.position = check2.position;
                break;
            case 3:
                player.transform.position = check3.position;
                break;
        }
        
        Physics.SyncTransforms();
        playerRB.velocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;
        levelUI.SetActive(false);
        GamePaused = false;
        Time.timeScale = 1f;
    }
}
