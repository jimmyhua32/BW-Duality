using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleEnemyScript : EnemyScript
{

    public Sprite blackSprite;
    public Sprite whiteSprite;
    public float freq;
    public float magn;
    
    private float speed;
    private Vector3 pos;
    private SpriteRenderer spriteRenderer;

    new void Start()
    {
        base.Start();
        pos = transform.position;
        magn = Random.Range(2, magn + 1);
        speed = Random.Range(4, 10);
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (gameObject.tag == "EnemyB")
        {
            spriteRenderer.sprite = blackSprite;
        }
        else
        {
            spriteRenderer.sprite = whiteSprite;
        }
        gameObject.AddComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        pos += transform.right * Time.deltaTime * speed * -1;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * freq) * magn;
    }
}
