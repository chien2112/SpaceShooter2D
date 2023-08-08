using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    public float Damage { get => damage;}
    public float Speed { get => speed;}

    public void SetBulletDamage(float dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            this.gameObject.SetActive(false);
        }
    }

}
