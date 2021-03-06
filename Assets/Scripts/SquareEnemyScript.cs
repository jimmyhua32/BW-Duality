﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEnemyScript : EnemyScript
{

    public Sprite blackSprite;
    public Sprite whiteSprite;

    private float speed;
    private SpriteRenderer spriteRenderer;
    

    new void Start()
    {
        base.Start();
        speed = Random.Range(7, 15);
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

    private void FixedUpdate()
    {
        rigid.velocity = Vector2.left * speed;
    }
}
