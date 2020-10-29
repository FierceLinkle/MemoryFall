using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            //Debug.Log("Game Over");
            Restart();
            //SceneManager.LoadScene("MainMenu");
        }

    }

    //Make a game over screen!
    void Restart ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
