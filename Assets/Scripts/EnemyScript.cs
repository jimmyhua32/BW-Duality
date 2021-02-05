using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    protected Rigidbody2D rigid;
    private float killTime = 10f;
    protected bool black;

    protected void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, killTime);
        black = Random.Range(-1, 2) > 0;
        if (black)
        {
            gameObject.tag = "EnemyB";
        } else
        {
            gameObject.tag = "EnemyW";
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "EnemyB" || collision.gameObject.tag == "EnemyW"
             || collision.gameObject.tag == "Flip")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}
