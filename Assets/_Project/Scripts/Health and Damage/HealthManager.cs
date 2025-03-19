using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int _startHealth = 100;
    public int health { get; private set; }
    public void SetHealth(int value)
    {
        health = value;
        if (health < 0)
        {
            health = 0;
            On0Health?.Invoke();
        }
    }
    public void ChangeHealth(int value)
    {
        health += value;
        if (health < 0)
        {
            health = 0;
            On0Health?.Invoke();
        }
    }

    public static event Action On0Health;
}

