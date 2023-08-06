using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected AudioClip shootingClip;
    [SerializeField] protected AudioMixerGroup audioMixerGroup;
    [SerializeField] protected Animator anim;
    [Space(10)]
    [SerializeField] protected SOWeapon weaponData;
    [Space(10)]
    [SerializeField] protected int level;
    [SerializeField] protected float fireRate; //animation speed
    [SerializeField] protected float damage;
    [SerializeField] protected float bulletSpeed;
    [Space(10)]
    [SerializeField] protected Transform shootingPoint;

    public void Init()
    {
        anim = GetComponent<Animator>();
        level = SavingSystem.Instance.GetDataWeaponByName(weaponData.weaponName).currentLevel;
        fireRate = weaponData.fireRate * weaponData.fireRateMultiplier * level;
        bulletSpeed = weaponData.bulletSpeed;
        damage = weaponData.damage * weaponData.damageMultiplier * level;
        anim.speed = fireRate;
    }
    public void DoShoot()
    {
        anim.SetBool("isShooting", true);
    }

    public void StopAnim()
    {
        anim.SetBool("isShooting", false);
    }
    public void StartAnim()
    {       
    }
    
}
