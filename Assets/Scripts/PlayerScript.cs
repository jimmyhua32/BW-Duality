using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float speed;

    private CamScript camScript;
    private Rigidbody2D rigid;
    private bool black = true;

    // Start is called before the first frame update
    void Start()
    {
        camScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamScript>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once at a fixed interval, independent of frame rate
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigid.velocity = movement.magnitude > 0 ? movement * speed : Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == (black ? "EnemyW" : "EnemyB"))
        {
            camScript.PlayExplosion();
            camScript.TriggerShake(0.7f, 5f);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Invoke("Reset", 2f);
        }
        if (collision.gameObject.tag == (black ? "EnemyB" : "EnemyW"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    public void Flip()
    {
        if (black)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        } else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        black = !black;
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Instantiate(gameObject);
    }
}
