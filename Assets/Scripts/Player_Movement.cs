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

    public static float newTimeScale = 1;

    public GameObject coinPickUp;
    public GameObject coinPickUp2;
    public GameObject coinPickUp3;
    public GameObject healthPickUp;
    public GameObject healthPickUp2;

    AudioSource audioSource;

    public AudioClip damageTake;
    public AudioClip GameOverS;
    public AudioClip coinCollect;
    public AudioClip healthCollect;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody.AddForce(0, 0, 30000 * Time.deltaTime);

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        audioSource = GetComponent<AudioSource>();
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

        
        //Debug
        if (Input.GetKey("v"))
        {
            //FindObjectOfType<GameOver>().EndGame();
        }
        if (Input.GetKey("m"))
        {
            //FindObjectOfType<Stage>().ResetHighScore();

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
        if (col.collider.tag == "Start")
        {
            Time.timeScale = 1f;
        }

        if (col.collider.tag == "Bottom")
        {
            //Rigidbody.AddForce(0, 1000000 * Time.deltaTime, 0);
            bottomHit = true;           
        }

        if (col.collider.tag == "Top")
        {
            transform.position = new Vector3(186, 10, 12);
            bottomHit = false;
            Stage.stageLevel++;
            ResetPickups();
        }

        if (col.collider.tag == "TopS2")
        {
            transform.position = new Vector3(337, 10, 12);
            bottomHit = false;
            Stage.stageLevel++;
            ResetPickups();
        }

        if (col.collider.tag == "TopS3")
        {
            transform.position = new Vector3(0, 10, 12);
            bottomHit = false;
            Stage.stageLevel = 1;
            Stage.worldLevel++;
            ResetPickups();
            FindObjectOfType<Stage>().NextWorld();
            Time.timeScale += 0.2f;
            newTimeScale = Time.timeScale;
        }

        if (col.collider.tag == "Obstacle")
        {
            TakeDamage(1);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Coin")
        {
            coinPickUp.SetActive(false);
            coinPickUp2.SetActive(false);
            coinPickUp3.SetActive(false);
            audioSource.PlayOneShot(coinCollect, 0.2F);
            FindObjectOfType<Score>().CoinPickUp();

            //Debug.Log("Coin picked up");
        }
        if (col.tag == "Health")
        {
            if (currentHealth < 4)
            {
                currentHealth++;
                healthBar.SetHealth(currentHealth);
                audioSource.PlayOneShot(healthCollect, 0.2F);
                healthPickUp.SetActive(false);
                healthPickUp2.SetActive(false);

                //Debug.Log("health restored");
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            FindObjectOfType<GameOver>().EndGame();
            //audioSource.PlayOneShot(GameOverS, 0.5F);
        }
        else
        {
            audioSource.PlayOneShot(damageTake, 0.5F);
        }
    }

    public void ResetPhysics()
    {
        bottomHit = false;
    }

    public void ResetHealth()
    {
        currentHealth = 4;
    }

    public void ResetPickups()
    {
        coinPickUp.SetActive(true);
        coinPickUp2.SetActive(true);
        coinPickUp3.SetActive(true);
        healthPickUp.SetActive(true);
        healthPickUp2.SetActive(true);
    }

    public void GameOverSound()
    {
        audioSource.PlayOneShot(GameOverS, 0.5F);
    }
}

