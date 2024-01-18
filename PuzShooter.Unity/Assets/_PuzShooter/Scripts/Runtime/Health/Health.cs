using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public abstract Action OnDead { get; set; }

    public abstract void Accept(IHealthVisitor health);
    public abstract void Destroy();
}
