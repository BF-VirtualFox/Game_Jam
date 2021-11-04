using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyAITypeA : MovementController
{
    [SerializeField] private int speed;
    [SerializeField] private Transform enemy;
    [SerializeField] private float jumpPower;
    [SerializeField] private Animator animator;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform target;

    private Vector2 _direction;
    private bool _jumpRequested;
    private bool _canJump;
    private bool _isAgro = false;

    

    void Update()
    {
        //Fire();
        Debug.Log(_isAgro);
        if (_isAgro)
        {
            Move();
        }
            
    }
    
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

    private void Move()
    {
        _direction = target.position-transform.position;
        _direction.Normalize();    
        var newPos = AsVector2(transform.position);
        newPos += _direction.normalized * Time.deltaTime * speed;
        transform.position = newPos;
    }

    public override void Move(Vector2 direction)
    {
        throw new NotImplementedException();
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
        if(other.CompareTag(target.tag)) _isAgro = true;    
    }

    private static Vector2 AsVector2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.y);
    }
}

