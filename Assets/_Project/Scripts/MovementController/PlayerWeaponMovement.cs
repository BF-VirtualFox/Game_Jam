using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerWeaponMovement : MovementController
{
    [SerializeField] private int speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float range;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Transform player;
    [SerializeField] private float intervalAttack;
    [SerializeField] private int damage;
    
    private Vector2 _direction;
    private bool _jumpRequested;
    private bool _canJump;
    private bool _canAttack;
    private bool _attacking;

    private void Start()
    {
        haveAttack = true;
        StartCoroutine(Attacking());
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
            player.localScale = new Vector3(-1, 1,1);
        }

        if (v.x > 0)
        {
            player.localScale = new Vector3(1, 1,1);
        }
        
        animator.SetFloat("speed", Math.Abs(v.x));
        rb.velocity = v;
    }

    public override void Move(Vector2 direction)
    {
        _direction = direction;
    }

    public override void Jump()
    {
        if (_canJump)
        {
            _jumpRequested = true;
        }
    }

    public override void Attack()
    {
        _canAttack = true;
            if (!_attacking)
            {
                StartCoroutine(Attacking());
            }
    }

    private IEnumerator Attacking()
    {
        _attacking = true;
        if (_canAttack)
        {
            animator.SetTrigger("attack");
        
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.attachedRigidbody.GetComponent<Health>().TakeDamage(damage);
            }
            
            yield return new WaitForSeconds(intervalAttack);
            _canAttack = false;
            yield return null;
        }
        _attacking = false;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
