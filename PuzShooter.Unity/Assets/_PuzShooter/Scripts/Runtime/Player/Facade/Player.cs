using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private PlayerCharacteristics _characteristics;

    private Movement _movement;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _movement = GetComponent<Movement>();
        _movement.Init(_characterController, _characteristics);

        PlayerFacade.Init(_characterController, _movement, _characteristics);
    }
}
