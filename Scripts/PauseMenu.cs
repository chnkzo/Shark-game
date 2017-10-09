using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseUI;

    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;   //pause is the opposite sate of what it is if pause then true vice versa
        }

        if (paused == true)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;  //Setting the time to 0 so nothing happens
        }

        if (paused == false)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;  // if 0.3 we can do slomo WOAH!!!!
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
