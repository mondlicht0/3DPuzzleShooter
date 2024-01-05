using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Type", menuName = "Bullet/Bullet Type")]
public class BulletCharacteristics : ScriptableObject
{
    public bool IsPlayersBullet;
    public float Speed = 10f;

    public bool IsBouncy;
    public int MaxNumOfBounces = 3;
    public bool IsThroWalls;
}
