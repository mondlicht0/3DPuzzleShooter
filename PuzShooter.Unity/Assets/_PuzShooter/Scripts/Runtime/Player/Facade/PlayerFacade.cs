using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerFacade
{
    public static CharacterController PlayerController { get; private set; }
    public static Movement Movement { get; private set; }
    public static PlayerCharacteristics Characteristics { get; private set; }

    public static bool IsInitialized { get; private set; }

    public static void Init(CharacterController playerController, Movement movement, PlayerCharacteristics characteristics)
    {
        Movement = movement;
        PlayerController = playerController;
        Characteristics = characteristics;

        IsInitialized = true;
    }

    private static void CheckClassInit()
    {
        if (!IsInitialized)
        {
            throw new Exception("Player Facade is not initialized");
        }
    }
}
