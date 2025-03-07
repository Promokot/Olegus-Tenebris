using System;
using UnityEngine;

public class HealthManager
{
    public int health { get; private set; }
    public void Update(float deltaTime)
    {
        //
    }
    public void SetHealth(int value)
    {
        health = value;
        if (health < 0)
        {
            health = 0;
            OnDeath?.Invoke();
        }
    }
    public void ChangeHealth(int value)
    {
        health += value;
        if (health < 0)
        {
            health = 0;
            OnDeath?.Invoke();
        }
    }
    public HealthManager()
    {

    }
    public static event Action OnDeath;
}