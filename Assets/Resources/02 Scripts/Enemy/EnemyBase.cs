using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Audio;
using System.Collections.Generic;


public abstract class EnemyBase : LivingEntity, IDroppable
{
    private float enemySpeed;
    private float enemyDamage;
    private GameObject enemyBulletPrefab;
    private Sprite phase2Sprite;
    private string enemyName;
    private AudioClip dieClip;
    private AudioMixerGroup audioMixerGroup;

    protected List<GameObject> items = new List<GameObject>();

    [SerializeField] private SOEnemy soEnemy;

    public float EnemyDamage { get => enemyDamage; }
    public GameObject EnemyBulletPrefab { get => enemyBulletPrefab; }
    public float EnemySpeed { get => enemySpeed; }
    public string EnemyName { get => enemyName; }
    public float CurrentHp { get => currentHealth; }
    public float Hp { get => health; }
    public bool IsDead { get => isDead; }
    public Sprite Phase2Sprite { get => phase2Sprite; set => phase2Sprite = value; }

    private void OnEnable()
    {
        Initial();
    }
    protected override void Start()
    {
        OnDeath += EnemyDie;
        OnDeath += DropItem;
    }
    protected void EnemyDie()
    {
        isDead = true;
        SoundManager.Instance.PlayClip(dieClip, audioMixerGroup);  
    }
    public void Initial()
    {
        isDead = false;
        enemyName = soEnemy.enemyName;
        health = soEnemy.health;
        enemyDamage = soEnemy.damage;
        enemySpeed = soEnemy.speed;
        currentHealth = health;
        GetComponent<SpriteRenderer>().sprite = soEnemy.sprite;
        phase2Sprite = soEnemy.phase2Sprite;

        dieClip = soEnemy.dieClip;
        audioMixerGroup = soEnemy.audioMixerGroup;
        enemyBulletPrefab = soEnemy.bulletPrefab;
        items = soEnemy.droppedItems;

        enemyBulletPrefab.GetComponent<EnemyBullet>().SetBulletDamage(enemyDamage);
        FlyPathAgent agent = GetComponent<FlyPathAgent>();
        agent.FlySpeed = soEnemy.flySpeed;
        agent.NextIndex = 0;
    }

    public virtual void DropItem()
    {
    }
}
