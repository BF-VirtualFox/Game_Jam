using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyAITypeA : MovementController
{
    [SerializeField] private int speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Animator animator;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform hero;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float range;
    [SerializeField] private LayerMask heroLayers;
    
    private bool _jumpRequested;
    private bool _canJump;
    private bool _isAgro = false;
    private float _sleepDuration;
    private Vector2 _direction;
    private Vector2 _velocity;

    

    void Update()
    {
        _direction = hero.position - transform.position;
        _direction.Normalize();
    }
    
    private void FixedUpdate()
    {
        _velocity = rb.velocity;
        if (_isAgro)
        {
            Move(_direction);
        }
        
        if(_velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1,1);
        }

        if (_velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1,1);
        }
    }
    /*
    private void FixedUpdate()
    {
        var v = rb.velocity;
        v.x = _direction.x * speed;
        _canJump = groundCheck.IsGrounded();
        animator.SetBool("jump", !_canJump);
        if (_canJump && _jumpRequested)
        {
            v.y = jumpPower;
            _jumpRequested = false;
            _canJump = false;
        }

        if(v.x < 0)
        {
            enemy.localScale = new Vector3(-1, 1,1);
        }

        if (v.x > 0)
        {
            enemy.localScale = new Vector3(1, 1,1);
        }
        
        animator.SetFloat("speed", Math.Abs(v.x));
        rb.velocity = v;
        Debug.Log(_canJump);
    }
    */

    public override void Move(Vector2  direction)
    {
        animator.SetFloat("speed", Math.Abs(_velocity.x));
        var velocityAdjust = rb.velocity;
        velocityAdjust.y = 0;
        rb.AddForce(_direction * speed - velocityAdjust, ForceMode2D.Force);
    }

    public override void Jump()
    {
        if (_canJump)
        {
            _jumpRequested = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(hero.tag)) 
            _isAgro = true;    
    }

    public override void Attack()
    {
        animator.SetTrigger("attack");
        
        Collider2D[] hitHero = Physics2D.OverlapCircleAll(attackPoint.position, range, heroLayers);

        foreach (Collider2D hero in hitHero)
        {
            Debug.Log("test attack");
        }
    }
}

