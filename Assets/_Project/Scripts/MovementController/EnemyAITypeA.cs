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
    [SerializeField] private Transform hero;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private float range;
    [SerializeField] private LayerMask heroLayers;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private int damage;
    [SerializeField] private float intervalAttack;
    [SerializeField] private float rangeDetection;
    
    private bool _isAgro = false;
    private bool _canAttack;
    private bool _attacking;
    private bool _canMove;
    private Vector2 _direction;
    private Vector2 _velocity;
    

    //Si l'ennemie tue le jouer cela renvoie une erreur -> voir si c'est ici qu'il faut gérer ça
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
        _velocity = rb.velocity;
        _canMove = true;
        
        if(Physics2D.Raycast(detectionPoint.position, new Vector2(transform.localScale.x,0f), rangeDetection, heroLayers))
        {
            _canMove = false;
            animator.SetFloat("speed", 0f);
            Attack();
        }
        
        if(Physics2D.Raycast(detectionPoint.position, new Vector2(transform.localScale.x,0f), rangeDetection, groundLayers))
        {
            Jump();
        }

        if (_isAgro && _canMove)
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (heroLayers == (heroLayers | 1 << other.gameObject.layer))
            _isAgro = true;
    }

    public override void Move(Vector2  direction)
    {
        animator.SetFloat("speed", Math.Abs(_velocity.x));
        var velocityAdjust = rb.velocity;
        velocityAdjust.y = 0;
        rb.AddForce(_direction * speed - velocityAdjust, ForceMode2D.Force);
    }

    public override void Jump()
    {
        rb.AddForce(new Vector2(0f, 1f) * jumpPower, ForceMode2D.Impulse);
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

    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(detectionPoint.position, new Vector2(transform.localScale.x,0f) * rangeDetection);
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}

