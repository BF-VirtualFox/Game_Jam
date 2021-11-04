using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovementController : MonoBehaviour
{
    private Rigidbody2D _rb;

    protected Rigidbody2D rb => _rb;

    protected void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public abstract void Move(Vector2 direction);
    
    public abstract void Jump();

    public abstract void Attack();
}
