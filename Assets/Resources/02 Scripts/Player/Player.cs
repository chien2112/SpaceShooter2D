using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : LivingEntity
{
    [SerializeField] float moveSpeed;
    [SerializeField] float extraSpeedMultiplier;
    [SerializeField] Transform weaponHolder;

    [SerializeField] bool autoShoot;
    [SerializeField] bool isInMenu;

    [SerializeField] Slider sliderHP;

    [SerializeField] AudioClip hurtClip;
    [SerializeField] AudioClip pickupItemClip;
    [SerializeField] AudioMixerGroup audioMixerGroup;

    public List<Weapon> weapons = new List<Weapon>();
    GameStateManager gameStateManager;
    public float CurHealth { get => CurrentHealth; set => CurrentHealth = value; }

    private void Awake()
    {   
        weaponHolder = transform.GetChild(0);
        health = 100f;
        autoShoot = false;
        gameStateManager = GameStateManager.Instance;
        OnDeath += PlayerDie;
    }

    protected override void Start()
    {
        base.Start();
        SavingSystem.Instance.LoadWeaponList();
    }
    private void Update()
    {
        Pause();
        if (GameStateManager.Instance.GetState() == GameState.Pausing) return;
        AutoShoot();
        Shoot();
        Move();
    }
    void Move()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var extraSpeed = Vector2.Distance(mousePos, transform.position);
        extraSpeed *= extraSpeedMultiplier;
        var speed = (moveSpeed + extraSpeed) / 1000;
        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed);
    }
    void Shoot()
    {
        if (Input.GetMouseButton(0) && !isInMenu)
        {
            foreach (Weapon wp in weapons)
            {
                wp.DoShoot();
            }
        }
    }
    void AutoShoot()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isInMenu)
        {
            autoShoot = !autoShoot;
        }
        if (autoShoot)
        {
            foreach (Weapon wp in weapons)
            {
                wp.DoShoot();
            }
            return;
        } 
    }
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isInMenu)
        {        
            if(gameStateManager.GetState() == GameState.Playing)
            {
                gameStateManager.SetState(GameState.Pausing);
            }
            else if (gameStateManager.GetState() == GameState.Pausing)
            {
                gameStateManager.SetState(GameState.Playing);
            }
        }       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            SoundManager.Instance.PlayClip(hurtClip, audioMixerGroup);
            EnemyBase enemyBase = collision.GetComponent<EnemyBase>();
            TakeDamage(enemyBase.EnemyDamage);
            UpdateSliderHP();
        }
        if (collision.CompareTag("EnemyBullet"))
        {
            SoundManager.Instance.PlayClip(hurtClip, audioMixerGroup);
            EnemyBullet bullet = collision.GetComponent<EnemyBullet>();
            TakeDamage(bullet.Damage);
            collision.gameObject.SetActive(false);
            UpdateSliderHP();
        }
        if (collision.CompareTag("Item"))
        {
            SoundManager.Instance.PlayClip(pickupItemClip, audioMixerGroup);
            collision.GetComponent<IPickable>().Pickup(this);
            collision.gameObject.SetActive(false);
            UpdateSliderHP();
        }
    }
    void UpdateSliderHP()
    {
        sliderHP.value = currentHealth;
    }

    void PlayerDie()
    {
        gameStateManager.SetState(GameState.Lose);
    }
}


