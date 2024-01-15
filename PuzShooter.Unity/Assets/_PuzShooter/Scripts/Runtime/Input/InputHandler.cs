using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Controls _controls;
    private InputAction _movementInput => _controls.Gameplay.Movement;

    public Vector2 MovementInputDirection { get; private set; }

    private void Awake()
    {
        _controls = new Controls();

        SubscribeOnGameplayMethods();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void SubscribeOnGameplayMethods()
    {
        //_movementInput.performed += ctx => PlayerFacade.Movement.Move(_movementInputDirection, PlayerFacade.Characteristics.MovementSpeed);
    }
}
