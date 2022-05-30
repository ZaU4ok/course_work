﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMonster : Entity
{
    private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;


    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        dir = transform.right;
        lives = 3;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);

        if (colliders.Length > 0) dir *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log("moving monster" + lives);
        }
        if (lives < 1)
            Die();
    }
}
