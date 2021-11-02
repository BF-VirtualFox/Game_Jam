using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGroundCheck : GroundCheck
{
    [SerializeField] private BoxOverlap box;
    [SerializeField] private LayerMask groundLayer;

    public override bool IsGrounded()
    {
        return box.Check(transform.position, groundLayer);
    }

    private void OnDrawGizmos()
    {
        box.Debug(transform.position, groundLayer, Color.green, Color.red);
    }
}