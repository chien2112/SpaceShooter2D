using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float health;
    public float CurrentHealth { get; protected set; }
    protected bool dead;

    public event Action OnDeath;

    protected virtual void Start()
    {
        CurrentHealth = health;
    }

    public virtual void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        gameObject.SetActive(false);
    }

    public virtual void TakeHit(float damage, Vector2 hitPoint, Vector2 hitDirection)
    {
        TakeDamage(damage);
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0 && !dead)
        {
            Die();
        }
    }
}
