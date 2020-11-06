using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject GameOverUI;
    public GameObject Player;

    bool gameEnded = false;

    public Transform StartW;
    public Transform FinishW;

    public Transform World;

    public Transform Score;
    public Transform SStartW;
    public Transform SFinishW;

    [Range(0, 1)]
    public float t;

    public float speed;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (gameEnded == true)
        {
            timer += Time.deltaTime;

            World.position = Vector3.Lerp(StartW.position, FinishW.position, (timer * speed) * t);

            World.localScale = Vector3.Lerp(StartW.localScale, FinishW.localScale, (timer * speed) * t);

            Score.position = Vector3.Lerp(SStartW.position, SFinishW.position, (timer * speed) * t);

            Score.localScale = Vector3.Lerp(SStartW.localScale, SFinishW.localScale, (timer * speed) * t);
        }
    }


    public void EndGame()
    {
        if (gameEnded == false)
        {
            //gameEnded = true;
            //Debug.Log("Game Over");
            End();
            StartCoroutine(Restart());
            //SceneManager.LoadScene("MainMenu");
        }

    }

    void End ()
    {
        //End game state
        FindObjectOfType<Player_Movement>().GameOverSound();
        GameOverUI.SetActive(true);
        Time.timeScale = 0.4f;
        gameEnded = true;
        //Destroy(Player);
        //FindObjectOfType<Stage>().UpdateHighScore();
        //SceneManager.LoadScene("MainMenu");
    }

    IEnumerator Restart()
    {
        //End game state length
        yield return new WaitForSeconds(2.5f);
        //Reset world
        FindObjectOfType<Player_Movement>().ResetPhysics();
        FindObjectOfType<Player_Movement>().ResetPickups();
        FindObjectOfType<Stage>().ResetScore();
        FindObjectOfType<Score>().Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenu");
    }
}
