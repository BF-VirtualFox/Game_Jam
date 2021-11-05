using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


// si on fait des changement d'input ou des rajouts il faut regénérer la class PlayerInputs
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MovementController movementCtrl;
    private PlayerInputs _playerInputs;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _playerInputs.Player.Enable();
        _playerInputs.Player.Jump.performed += Jump;
        _playerInputs.Player.Attack.performed += Attack;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if(movementCtrl.haveAttack)
            movementCtrl.Attack();
    }

    private void Update()
    {
        var x = _playerInputs.Player.Move.ReadValue<float>();
        var dir = new Vector2(x, 0);
        movementCtrl.Move(dir);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        movementCtrl.Jump();
    }
}
