using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int life;
    public Rigidbody2D rb2d;
    public float speed;
    public Vector2 direction;
    public GameObject PlayerBullet;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y= Input.GetAxisRaw("Vertical");  

        rb2d.velocity = direction * speed;
    }
    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            GameObject obj = Instantiate(PlayerBullet);
            obj.transform.position = transform.position;
            obj.GetComponent<PlayerBullet>();
        }
    
    }

    //Bala   public Vector2 Direction {set => direction + value;}
}
