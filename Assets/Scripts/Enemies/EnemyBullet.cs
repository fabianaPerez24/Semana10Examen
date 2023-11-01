using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //public Vector2 direction;
    public float speed;
    private Transform player;
    public Rigidbody2D rb2d;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction= (target.transform.position - transform.position).normalized * speed;
    rb2d.velocity = new Vector2(direction.x, direction.y);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
