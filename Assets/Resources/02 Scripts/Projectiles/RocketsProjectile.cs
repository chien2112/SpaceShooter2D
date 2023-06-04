using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsProjectile : Projectile
{
    public override void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public override void OnEnable()
    {
        rb.velocity = Vector2.up * speed;
        Invoke("SelfDestruct", 2f);
        rb.gravityScale = 0;
    }
    private void Update()
    {
        rb.gravityScale -= 1.5f*Time.deltaTime;
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
    public override void SelfDestruct()
    {
        gameObject.SetActive(false);
    }
}
