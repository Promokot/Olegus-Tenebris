using UnityEngine;

public class DamageManager
{
    public DamageManager()
    {
        HealthManager.OnDeath += Die;
    }

    void Die()
    {

    }
}
