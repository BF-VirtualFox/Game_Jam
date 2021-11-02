using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MovementController movementCtrl;

    private void Update()
    {
        var dir = new Vector2(Input.GetAxis("Horizontal"), 0);
        movementCtrl.Move(dir);
        if (Input.GetButtonDown("Jump"))
            movementCtrl.Jump();
    }
}
