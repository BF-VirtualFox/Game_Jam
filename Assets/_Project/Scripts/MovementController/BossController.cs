using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Serialization;
using UnityEngine;

public class BossController : MovementController
{
    [SerializeField] private int speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform hero;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform detectionPlayerPoint;
    [SerializeField] private Transform detectionGroundPoint;
    [SerializeField] private float range;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private LayerMask heroLayers;
    [SerializeField] private int damage;
    [SerializeField] private float intervalAttack;
    [SerializeField] private float rangeDetectionPlayer;
    [SerializeField] private float rangeDetectionGround;
    
    private bool _isAgro = false;
    private bool _canAttack;
    private bool _attacking;
    private bool _canMove;
    private Vector2 _direction;
    private Vector2 _velocity;
    private bool _isStun = false;
    private bool _isStopped = true;
    
    
    void Update()
    {
        if (hero)
        {
            _direction = hero.position - transform.position;
            _direction.Normalize();
        }
        else
            Destroy(gameObject);
    }
    
    private void FixedUpdate()
    {
        if (!_isStun)
        {
            _velocity = rb.velocity;
            _canMove = true;

            if(Physics2D.Raycast(detectionPlayerPoint.position, new Vector2(transform.localScale.x,0f), rangeDetectionPlayer, heroLayers))
            {
                _canMove = false;
                animator.SetFloat("speed", 0f);
                Attack();
            }
            
            if(Physics2D.Raycast(detectionGroundPoint.position, new Vector2(transform.localScale.x,0f), rangeDetectionGround, groundLayers))
            {
                _canMove = false;
                if(!_isStopped)
                    Stop();
                animator.SetFloat("speed", 0f);
            }

            if (_isAgro && _canMove)
            {
                Move(_direction);
            }
        
            if(_direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1,1);
            }

            if (_direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1,1);
            } 
        }
    }

    private void Stop()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        _isStopped = true;
        rb.constraints = RigidbodyConstraints2D.None;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (heroLayers == (heroLayers | 1 << other.gameObject.layer))
            _isAgro = true;
    }

    public override void Move(Vector2  direction)
    {
        _isStopped = false;
        animator.SetFloat("speed", Math.Abs(_velocity.x));
        var velocityAdjust = rb.velocity;
        velocityAdjust.y = 0;
        rb.AddForce(_direction * speed - velocityAdjust, ForceMode2D.Force);
    }

    public override void Jump()
    {
        Debug.Log("Boss doesn't jump because he ate too much");
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
        
            Collider2D[] hitHero = Physics2D.OverlapCircleAll(attackPoint.position, range, heroLayers);

            foreach (Collider2D hero in hitHero)
            {
                hero.attachedRigidbody.GetComponent<Health>().TakeDamage(damage);
            }
            
            yield return new WaitForSeconds(intervalAttack);
            _canAttack = false;
            yield return null;
        }
        _attacking = false;
    }

    public void Stun()
    {
        _isStun = true;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        animator.SetBool("stun", true);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(detectionPlayerPoint.position, new Vector2(transform.localScale.x,0f) * rangeDetectionPlayer);
        Gizmos.DrawRay(detectionGroundPoint.position, new Vector2(transform.localScale.x,0f) * rangeDetectionGround);
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
