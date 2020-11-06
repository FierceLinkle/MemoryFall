using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform Left;
    public Transform Right;

    [Range(0,1)]
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
        timer += Time.deltaTime;

        //moves platform between two points back and forth
        transform.position = Vector3.Lerp(Left.position, Right.position, Mathf.PingPong(timer * speed, t));
    }
}
