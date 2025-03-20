using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[Serializable]
public class Damage
{
    public Damage(int amount, DamageType damageType, DamageDirection direction)
    {
        Amount = amount;
        DamageType = damageType;
        _direction = direction;
    }
    public int Amount
    {
        get { return _amount; }
        private set { _amount = value; }
    }
    public DamageType DamageType
    {
        get { return _damageType; }
        private set { _damageType = value; }
    }
    public DamageDirection Direction
    {
        get { return _direction; }
        private set { _direction = value; }
    }

    [SerializeField] private int _amount;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private DamageDirection _direction;
}

public enum DamageType
{
    Physical, Magical
}
