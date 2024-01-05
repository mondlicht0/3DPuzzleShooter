using UnityEngine;

[CreateAssetMenu(fileName = "Player Characteristics", menuName = "Characteristics/Player Characteristics")]
public class PlayerCharacteristics : ScriptableObject
{
    public float MovementSpeed = 1f;
    public float XSensitivity = 1f;
    public float YSensitivity = 1f;
}
