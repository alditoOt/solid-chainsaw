﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDead : MonoBehaviour
{
    private PlayerMovement movementScript;
    public bool dead = false;
    private Animator anim;
    private Rigidbody2D rb;

    private void Start()
    {
        movementScript = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyBullet"))
        {
            dead = true;
            anim.SetBool("Dead", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            movementScript.moveSpeed = 0;
            movementScript.mousePosition = new Vector2(0f, 0f);
            Destroy(collision.gameObject);
        }
    }
}
