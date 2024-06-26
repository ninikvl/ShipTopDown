using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private GameInput _gameInput;
    
    public Vector2 RawMovement => _gameInput.Gameplay.Movement.ReadValue<Vector2>();
    public Vector2 Movement => RawMovement.normalized;

    public bool IsSpeedUp => _gameInput.Gameplay.SpeedUp.ReadValue<float>() == 1;
    public bool IsShoot => _gameInput.Gameplay.Shoot.ReadValue<float>() == 1;


    private void Awake()
    {
        _gameInput = new GameInput();
    }

    private void OnEnable()
    {
        _gameInput.Enable();
        _gameInput.Gameplay.ChangeWeaponNext.performed += OnChangeWeapon;
        _gameInput.Gameplay.ChangeWeaponPrevious.performed += OnChangeWeapon;

    }

    private void OnDisable()
    {
        _gameInput.Disable();
        _gameInput.Gameplay.ChangeWeaponNext.performed -= OnChangeWeapon;
        _gameInput.Gameplay.ChangeWeaponPrevious.performed -= OnChangeWeapon;
    }

    private void OnChangeWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.control.name == "e")
            PlayerShip.Instance.ChangePlayerActiveWeapon(true);
        else
            PlayerShip.Instance.ChangePlayerActiveWeapon(false);
    }
}
