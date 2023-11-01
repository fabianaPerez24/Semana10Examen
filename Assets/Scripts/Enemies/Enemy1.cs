using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy1 : MonoBehaviour
{
    public int life;
    public float speed;
    public Rigidbody2D rb2d;
    public Vector2 direction;

    public PlayerStats playerStats;

    public float timer;
    public float Maxtimer;
    //public GameObject Enemybullet;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
                if (collision.gameObject.CompareTag("playerbullet"))
        {
            life--;
            if (life <= 0)
            {
                Destroy(gameObject);

                playerStats.enemyCounter++;
                
            }
        }
        if (collision.gameObject.CompareTag("playerbullet2"))
        {
            life-=2;
            if (life <= 0)
            {
                Destroy(gameObject);
                playerStats.enemyCounter++;
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
                playerStats.enemyCounter++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeDirection();
    }
    void Move()
    {
        rb2d.velocity = direction * speed;
    }
    void ChangeDirection()
    {

        timer += Time.deltaTime;
        if(timer>=Maxtimer)
        {
            direction *= -1;
            timer = Time.deltaTime;
         timer = 0;
        }   
    }

}
