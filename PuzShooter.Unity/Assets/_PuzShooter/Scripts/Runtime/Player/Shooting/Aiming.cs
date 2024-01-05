using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;
    [SerializeField] private Camera _camera;

    private Controls _controls;
    private Vector3 _pointerInput;

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
        _controls = new Controls();
    }

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {
        Vector3 mousePosition = _controls.Gameplay.Aim.ReadValue<Vector2>();

        Vector3 worldMousePosition = _camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, _camera.transform.position.y));

        Vector3 lookDirection = worldMousePosition - transform.position;
        lookDirection.y = 0;

        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}

