using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{   
    public CharacterController PlayerController { get; private set; }
    public Movement Movement { get; private set; }

    public bool IsInitialized { get; private set; }

    public void Init(CharacterController playerController, Movement movement)
    {
        Movement = movement;
        PlayerController = playerController;

        IsInitialized = true;
    }

    private void CheckClassInit()
    {
        if (!IsInitialized)
        {
            throw new Exception("Player Facade is not initialized");
        }
    }
}
