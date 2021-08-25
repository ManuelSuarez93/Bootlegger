using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator animator;

    [SerializeField] float speed;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float velx = Input.GetAxis("Horizontal");
        float vely = Input.GetAxis("Vertical");
        rigid.velocity = new Vector2(velx* speed, vely* speed);

        if (rigid.velocity != Vector2.zero)
        {
            animator.SetBool("IsWalking", true);
            if(velx < 0 )
            {
                sprite.flipX = true;
            }
            if(velx > 0)
            {
                sprite.flipX = false;
            }

        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        

    }
}
