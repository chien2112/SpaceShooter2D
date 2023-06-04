using UnityEngine;
using System.Collections;
using System;

public abstract class EnemyBase : LivingEntity
{
    public State currentState;
    public float enemySpeed = 5;

    private void Awake()
    {
        base.Start();
    }
}
public enum State
{
    Moving,
    Attacking
}