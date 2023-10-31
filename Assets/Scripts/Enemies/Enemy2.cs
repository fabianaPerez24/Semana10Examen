using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int life;
    public float speed;
    public Rigidbody2D rb2d;
    public Vector2 direction;
    public GameObject enemyBullet;

    public float timer;
    public float Maxtimer;
    //public GameObject Enemybullet;
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
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }  

        if (collision.gameObject.CompareTag("playerbullet2"))
        {
            life -= 2;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            life--;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }
    void Move()
    {
        rb2d.velocity = direction * speed;
    }
    void Shoot()
    {
        timer += Time.deltaTime;
        if(timer>=Maxtimer ) 
        {
            GameObject obj = Instantiate(enemyBullet);
            obj.transform.position = transform.position;
            obj.GetComponent<EnemyBullet>();
        timer = 0;
        }
    }
}
