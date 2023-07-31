using UnityEngine;

public class AutoCannonProjectile : Projectile
{
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnEnable()
    {
        rb.velocity = Vector2.up * speed;
    }

    public override void SelfDestruct()
    {
        gameObject.SetActive(false);
    }

}
