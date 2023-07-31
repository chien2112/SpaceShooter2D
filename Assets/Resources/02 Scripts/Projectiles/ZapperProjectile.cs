using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapperProjectile : Projectile
{
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }
    public override void SelfDestruct()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        Invoke("SelfDestruct", 1.5f);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBase>().TakeDamage(damage);
        }
    }
}
