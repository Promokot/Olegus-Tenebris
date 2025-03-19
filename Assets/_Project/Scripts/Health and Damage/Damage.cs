using System;
using UnityEngine;

[Serializable]
public class Damage
{
    public Damage(int amount, DamageType damageType, DamageDirection direction)
    {
        dAmount = amount;
        dDamageType = damageType;
        dDirection = direction;
    }
    public int dAmount { get; private set; }
    public DamageType dDamageType { get; private set; }
    public DamageDirection dDirection { get; private set; }
}

public enum DamageType
{
    Physical, Magical
}
