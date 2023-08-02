using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public abstract class Weapon : MonoBehaviour
{
    protected float animSpeed;
    [SerializeField] protected AudioClip shootingClip;
    [SerializeField] protected AudioMixerGroup audioMixerGroup;
    [SerializeField] protected Animator anim;
    [Space(10)]
    [SerializeField] protected bool isUnlocked;
    [SerializeField] protected int level;
    [SerializeField] protected SOWeapon weaponData;
    [Space(10)]
    [SerializeField] protected Transform shootingPoint;

    protected virtual void Awake()
    {
        animSpeed = weaponData.fireRate;
        anim = GetComponent<Animator>();
        SetFireRate(animSpeed);
    }

    public void DoShoot()
    {
        anim.SetBool("isShooting", true);
    }
    public void SetFireRate(float speed)
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
