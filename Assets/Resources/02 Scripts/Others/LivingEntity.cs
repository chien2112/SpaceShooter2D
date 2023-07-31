using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    protected float health;
    protected float currentHealth;

    protected float CurrentHealth
    {
        get { 
            return currentHealth; 
        }
        set {
            currentHealth = value;
            if(currentHealth > health)
            {
                currentHealth = health;
            }
            if (currentHealth <= 0 && !isDead)
            {
                Die();
            }       
        }
    }
    protected bool isDead;

    protected event Action OnDeath;

    protected virtual void Start()
    {
        currentHealth = health;
    }

    public virtual void Die()
    {
        isDead = true;
        OnDeath?.Invoke();
        gameObject.SetActive(false);
    }

    public virtual void TakeHit(float damage, Vector2 hitPoint, Vector2 hitDirection)
    {
        TakeDamage(damage);
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage; 
    }
}
