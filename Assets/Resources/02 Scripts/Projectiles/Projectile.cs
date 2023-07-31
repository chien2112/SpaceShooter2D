using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class Projectile : MonoBehaviour
{
    protected float damage;
    protected float speed;
    [SerializeField] protected SOWeapon weaponData;
    protected Rigidbody2D rb;

    [SerializeField] protected AudioClip explosionClip;
    [SerializeField] protected AudioMixerGroup audioMixerGroup;
    protected virtual void Awake()
    {
        damage = weaponData.damage;
        speed = weaponData.bulletSpeed;
    }
    public abstract void SelfDestruct();
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
