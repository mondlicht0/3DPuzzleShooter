using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<CharacterController>();
    }

    private void Move(Vector2 direction, float speed)
    {
        //_playerController.Move(direction * speed * Time.fixedDeltaTime);
    }
}
