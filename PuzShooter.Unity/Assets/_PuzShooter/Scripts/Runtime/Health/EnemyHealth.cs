using System;

public class EnemyHealth : Health
{
    public override Action OnDead { get; set; }

    public override void Accept(IHealthVisitor health)
    {
        health.Kill(this);
    }

    public override void Destroy()
    {
        OnDead?.Invoke();
        Destroy(gameObject);
    }
}
