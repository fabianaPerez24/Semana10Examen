using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int life;
    public float speed;
    public Rigidbody2D rb2d;
    public Vector2 direction;
    public GameObject enemyBullet;

    public PlayerStats playerStats;
    public float timer;
    public float Maxtimer;

    public float Bullettimer;
    public float BulletMaxtimer;
    // Start is called before the first frame update


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("playerbullet"))
        {
            life--;
            if(life <= 0)
            {
                Destroy(gameObject);
                GetComponent<CambiarScenes>();
                SceneManager.LoadScene("Victory");
            }

        }
        if (collision.gameObject.CompareTag("playerbullet2"))
        {
            life-=2;
            if (life <= 0)
            {
                Destroy(gameObject);
                GetComponent<CambiarScenes>();
                SceneManager.LoadScene("Victory");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            life--;
            if (life <= 0)
            {
                Destroy(gameObject);
                GetComponent<CambiarScenes>();
                SceneManager.LoadScene("Victory");
            }
        }

    }

    void Update()
    {
        ChangeAttack();

    }
    void ChangeAttack()
    {
        if(life>=5)
        {
            rb2d.velocity = direction * speed;  
            
            timer += Time.deltaTime;
            if (timer >= Maxtimer)
            {
            direction *= -1;
            timer = Time.deltaTime;
            timer = 0;
                if(life<=5)
                {
                    speed = 0;
                }
            }
        }
        else
        {
            Bullettimer += Time.deltaTime;
            if (Bullettimer >= BulletMaxtimer)
            {
                GameObject obj = Instantiate(enemyBullet);
                obj.transform.position = transform.position;
                obj.GetComponent<EnemyBullet>();
                Bullettimer = 0;
            }
        }
    }
}
