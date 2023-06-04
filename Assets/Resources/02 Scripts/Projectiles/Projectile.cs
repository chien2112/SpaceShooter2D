using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : ObjectPooling<Projectile>
{
    [SerializeField] protected float damage;  
    [SerializeField] protected float speed;
    protected Rigidbody2D rb;

    public abstract void Awake();
    public abstract void OnEnable();
    public abstract void OnTriggerEnter2D(Collider2D collision);
    public abstract void SelfDestruct();
}
