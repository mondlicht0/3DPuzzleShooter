using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Characteristics", menuName = "Characteristics/Player Characteristics")]
public class PlayerCharacteristics : ScriptableObject
{
    public float MovementSpeed { get; private set; }
    public float XSensitivity{ get; private set; }
    public float YSensitivity{ get; private set; }
}
