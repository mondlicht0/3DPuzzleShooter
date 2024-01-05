using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Type", menuName = "Bullet/Bullet Type")]
public class BulletCharacteristics : ScriptableObject
{
    public float Speed = 10f;

    public bool IsBouncy;
    public bool IsThroWalls;
}