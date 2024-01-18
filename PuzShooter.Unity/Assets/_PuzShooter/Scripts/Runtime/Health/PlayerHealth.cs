using System;

public class PlayerHealth : Health
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
