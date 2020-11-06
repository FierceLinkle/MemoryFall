using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    Text text;

    public static int coinScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + coinScore;
    }

    public void CoinPickUp()
    {
        coinScore += 100;
    }

    public void Reset()
    {
        coinScore = 0;
    }
}
