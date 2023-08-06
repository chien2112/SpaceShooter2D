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
    [Space(10)]
    [SerializeField] float moveSpeed;
    [SerializeField] float extraSpeedMultiplier;
    private bool autoShoot;
    public bool canTakeDamage;
    [Space(10)]
    [SerializeField] bool isInMenu;
    [Space(10)]
    [SerializeField] private Slider sliderHP;
    [Space(10)]
    [SerializeField] AudioClip hurtClip;
    [SerializeField] AudioClip pickupItemClip;
    [SerializeField] AudioMixerGroup audioMixerGroup;
    [Space(10)]
    public List<Weapon> weapons = new List<Weapon>();
    GameStateManager gameStateManager;
    public float CurHealth { get => CurrentHealth; set => CurrentHealth = value; }

    private void Awake()
    {
        canTakeDamage = true;
        isDead = false;
        health = 100f;
        autoShoot = false;
        gameStateManager = GameStateManager.Instance;
        OnDeath += PlayerDie;
        
    }
    
    protected override void Start()
    {
        base.Start();
        SavingSystem.Instance.LoadWeapon();
    }
    private void Update()
    {
        Pause();
        if (gameStateManager.GetState() == GameState.Pausing) return;
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
            collision.gameObject.SetActive(false);
            SoundManager.Instance.PlayClip(hurtClip, audioMixerGroup);
            if (!canTakeDamage) return;     
            EnemyBullet bullet = collision.GetComponent<EnemyBullet>();
            TakeDamage(bullet.Damage);
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
        isDead = true;
        gameStateManager.SetState(GameState.Lose);
    }
}


