using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string weaponName;
    [SerializeField] protected float damage;
    [SerializeField] protected float animSpeed;
    [SerializeField] protected Projectile projectile;
    protected Animator anim;
    [SerializeField] protected Transform shootingPoint;

    public virtual void Awake()
    {
        anim = GetComponent<Animator>();
        weaponName = gameObject.name;
    }

    public void DoShoot()
    {
        anim.SetBool("isShooting", true);
    }
    public void SetFireRate(int speed)
    {
        animSpeed = speed;
        anim.speed = animSpeed;
    }
    
    public void StopAnim()
    {
        anim.SetBool("isShooting", false);
    }
    public void StartAnim()
    {       
    }
}
