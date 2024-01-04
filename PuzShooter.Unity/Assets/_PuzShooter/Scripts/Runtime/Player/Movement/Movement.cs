using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Controls _controls;
    private CharacterController _playerController;
    private PlayerCharacteristics _characteristics;

    private Vector2 MovementInputDirection => _controls.Gameplay.Movement.ReadValue<Vector2>();

    public void Init(CharacterController playerController, PlayerCharacteristics characteristics)
    {
        _playerController = playerController;
        _characteristics = characteristics;
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Awake()
    {
        _playerController = GetComponent<CharacterController>();

        _controls = new Controls();
    }

    private void FixedUpdate()
    {
        Move(MovementInputDirection, _characteristics.MovementSpeed);
    }

    private void Move(Vector2 direction, float speed)
    {
        _playerController.Move(new Vector3(direction.x, 0, direction.y) * speed * Time.fixedDeltaTime);
    }
}
