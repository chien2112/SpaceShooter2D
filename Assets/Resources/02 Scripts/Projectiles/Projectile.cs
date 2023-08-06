using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected SOWeapon weaponData;
    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected AudioClip explosionClip;
    [SerializeField] protected AudioMixerGroup audioMixerGroup;
    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void OnEnable()
    {
    }

    protected void SelfDestruct()
    {
        gameObject.SetActive(false);
    }
    public void Init(float damage, float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
        this.damage = damage;
        rb.velocity = Vector2.up * bulletSpeed;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            SoundManager.Instance.PlayClip(explosionClip, audioMixerGroup);
            SelfDestruct();
            collision.GetComponent<EnemyBase>().TakeDamage(damage);
        }
        if (collision.CompareTag("DeadZone"))
        {
            SelfDestruct();
        }
    }

}
