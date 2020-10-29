using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public static int worldLevel = 1;
    public static int stageLevel = 1;
    Text text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "World: " + worldLevel + "-" + stageLevel;
    }
}
