using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int _startHealth = 100;
    public int health { get; private set; }
    public void SetHealth(int value)
    {
        health = value;
        CheckIfNoHealth();
    }
    public void ChangeHealth(int value)
    {
        health += value;
        CheckIfNoHealth();
        Debug.Log(health);
    }

    public event Action On0Health;
    private void Start()
    {
        health = _startHealth;
        On0Health += () => { Debug.Log("0 health event"); };

    }

    void CheckIfNoHealth()
    {
        if (health <= 0)
        {
            health = 0;
            On0Health?.Invoke();
            On0Health = null;
        }
    }

    
}

