using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    [Header("Physics")]
    public Rigidbody Rigidbody;

    public Transform player;

    [Tooltip("Speed when moving forward, in units/second")]
    [Range(0, 1000)]
    public float Speed;

    [Tooltip("Speed when moving backwards, in units/second")]
    [Range(0, 1000)]
    public float returningSpeed;

    public static bool bottomHit = false;

    public Health healthBar;

    public int maxHealth = 4;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody.AddForce(0, 0, 30000 * Time.deltaTime);

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            Rigidbody.AddForce(Speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            Rigidbody.AddForce(-Speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w"))
        {
            Rigidbody.AddForce(0, 0, Speed * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            Rigidbody.AddForce(0, 0, -Speed * Time.deltaTime, ForceMode.VelocityChange);
        }

        PlayerReturning();
    }

    void PlayerReturning()
    {
        if (bottomHit == true)
        {
            Rigidbody.AddForce(0, returningSpeed * Time.deltaTime, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Bottom")
        {
            //Rigidbody.AddForce(0, 1000000 * Time.deltaTime, 0);
            bottomHit = true;           
        }

        if (col.collider.tag == "Top")
        {
            transform.position = new Vector3(55, 10, 12);
            bottomHit = false;
            Stage.stageLevel++;
        }

        if (col.collider.tag == "Obstacle")
        {
            TakeDamage(1);   
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            FindObjectOfType<GameOver>().EndGame();
        }
    }
}

