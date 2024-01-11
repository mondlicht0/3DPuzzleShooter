using System;
using UnityEngine;

public static class PlayerFacade
{
    public static CharacterController PlayerController { get; private set; }
    public static Movement Movement { get; private set; }
    public static Shooting Shooting { get; private set; }
    public static Aiming Aiming { get; private set; }
    public static PlayerCharacteristics Characteristics { get; private set; }

    public static bool IsInitialized { get; private set; }

    public static void Init(CharacterController playerController, Movement movement, Aiming aiming, Shooting shooting, PlayerCharacteristics characteristics)
    {
        Movement = movement;
        Aiming = aiming;
        PlayerController = playerController;
        Characteristics = characteristics;
        Shooting = shooting;

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
