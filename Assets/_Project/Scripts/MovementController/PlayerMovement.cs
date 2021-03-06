using System;
using UnityEngine;

public class PlayerMovement : MovementController
{
    [SerializeField] private int speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;

    private Vector2 _direction;
    private bool _jumpRequested;
    private bool _canJump;

    private void Start()
    {
        haveAttack = false;
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

        if (v.x < 0)
            player.localScale = new Vector3(-1, 1, 1);
        if(v.x > 0)
            player.localScale = new Vector3(1, 1, 1);
        
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
        throw new NotImplementedException();
    }
}
