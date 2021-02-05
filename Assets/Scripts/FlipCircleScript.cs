using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlipCircleScript : MonoBehaviour
{

    public float speed;
    public float blinkTime;

    private Rigidbody2D rigid;
    private CamScript camScript;
    private ScoreScript scoreScript;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer background;
    private Color currColor = Color.black;
    private float lastBlink;
    private float killTime = 8f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        camScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamScript>();
        scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
        Destroy(gameObject, killTime);
    }

    // Update is called once per fixed interval
    void FixedUpdate()
    {
        rigid.velocity = Vector2.left * speed;
        if (Time.time - lastBlink > blinkTime)
        {
            if (currColor == Color.black)
            {
                spriteRenderer.color = Color.white;
                currColor = Color.white;
            } else
            {
                spriteRenderer.color = Color.black;
                currColor = Color.black;
            }
            lastBlink = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            camScript.TriggerShake(0.25f, 0.75f);
            camScript.PlayFlip();
            scoreScript.Flip();
            background.color = background.color == Color.black ? Color.white : Color.black;
            collision.gameObject.GetComponent<PlayerScript>().Flip();
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "EnemyB" || collision.gameObject.tag == "EnemyW")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}