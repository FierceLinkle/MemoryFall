using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    //public GameObject optionsMenuUI;

    //public string MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (GamePaused == true)
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
        //Time.timeScale = 1f;
        Time.timeScale = Player_Movement.newTimeScale;
        GamePaused = false;
    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Reset()
    {
        FindObjectOfType<Stage>().ResetHighScore();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        FindObjectOfType<Player_Movement>().ResetPhysics();
        FindObjectOfType<Player_Movement>().ResetPickups();
        FindObjectOfType<Stage>().ResetScore();
        FindObjectOfType<Score>().Reset();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
