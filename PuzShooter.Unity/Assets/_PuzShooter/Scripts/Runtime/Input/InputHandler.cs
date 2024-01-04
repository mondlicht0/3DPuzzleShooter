using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Controls _controls;

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
        // Example: _controls.Gameplay.Movement.performed += ctx => Move();
    }
}
