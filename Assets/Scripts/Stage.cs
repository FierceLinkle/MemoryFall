using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public static int worldLevel = 1;
    public static int stageLevel = 1;
    Text text;

    //public static int worldLevelH = 0;
    //public static int stageLevelH = 0;

    public Text highScoreW;
    public Text highScoreS;

    public static bool nextWorld = false;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        //Save high score
        highScoreW.text = PlayerPrefs.GetInt("HighScoreW", 0).ToString();
        highScoreS.text = PlayerPrefs.GetInt("HighScoreS", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Current world and stage
        text.text = "World: " + worldLevel + "-" + stageLevel;

        //Check if current score is valid for being the high score
        if (worldLevel >= PlayerPrefs.GetInt("HighScoreW", 0))
        {
            PlayerPrefs.SetInt("HighScoreW", worldLevel);
            highScoreW.text = worldLevel.ToString();

            if (stageLevel >= PlayerPrefs.GetInt("HighScoreS", 0))
            {
                PlayerPrefs.SetInt("HighScoreS", stageLevel);
                highScoreS.text = stageLevel.ToString();
            }

        }

        //Debug.Log(stageLevel);
        /*
        if (nextWorld == true)
        {
            highScoreS.text = stageLevel.ToString();
        }
        */

    }

    public void ResetScore()
    {
        worldLevel = 1;
        stageLevel = 1;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScoreW");
        PlayerPrefs.DeleteKey("HighScoreS");
    }

    public void NextWorld()
    {
        //highScoreS.text = stageLevel.ToString();
        PlayerPrefs.DeleteKey("HighScoreS");
    }

    public void UpdateHighScore()
    {
        /*
        if (worldLevel >= worldLevelH)
        {
            worldLevelH = worldLevel;

            if (stageLevel >= stageLevelH)
            {
                stageLevelH = stageLevel;
                //highScore.text = text.text;
            }
        }
        */

    }
}
