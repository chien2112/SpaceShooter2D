using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsProjectile : Projectile
{
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnEnable()
    {
        rb.velocity = Vector2.up * speed;
        rb.gravityScale = 0;
    }
    private void Update()
    {
        rb.gravityScale -= 3f*Time.deltaTime;
    }

    public override void SelfDestruct()
    {
        gameObject.SetActive(false);
    }
}
