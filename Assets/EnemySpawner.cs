using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemySpawner : MonoBehaviour
{
    FlyPath flyPath;
    private Transform spawnPoint;
    private Transform parent;
    [SerializeField] SOEnemy soEnemy;

    [SerializeField] float firstSpawnTimer;
    [SerializeField] float spawnTimer;
    
    [SerializeField] int quantity;

    [SerializeField] bool isTheFirstSpawner;
    [SerializeField] bool isTheLastSpawner;
    [SerializeField] bool canSpawn;

    [SerializeField] List<EnemySpawner> nextEnemySpawners;
    [SerializeField] private List<EnemyBase> enemies;

    [SerializeField] private int spawnCounter;
    private bool isFirstSpawn;

    private float _spawnTimer;
    private float _firstSpawnTimer;

    private GameState gameState;

    private void Awake()
    {
        if (isTheFirstSpawner)
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }

        _spawnTimer = spawnTimer;
        _firstSpawnTimer = firstSpawnTimer;

        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if(child.name == "EnemyHolder")
            {
                spawnPoint = child;
                parent = child;
            }
            if(child.name == "FlyPath")
            {
                flyPath = child.GetComponent<FlyPath>();
            }
        }
    }
    private void Start()
    {
        StartCoroutine(IRepeatChecking());
    }
    private void Update()
    {
        FirstSpawnCountdown();
        SpawnCountdown();

        if (isTheLastSpawner)
        {
            
        }
    }
    void SpawnCountdown()
    {
        if (!canSpawn) return;
        gameState = GameStateManager.Instance.GetState();
        if (gameState != GameState.Playing || !isFirstSpawn) return;

        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0 && spawnCounter < quantity)
        {
            _spawnTimer = spawnTimer;
            spawnCounter++;
            SpawnEnemy();
        }
    }
    void FirstSpawnCountdown()
    {
        if (!canSpawn) return;
        gameState = GameStateManager.Instance.GetState();
        if (gameState != GameState.Playing || isFirstSpawn) return;

        _firstSpawnTimer -= Time.deltaTime;
        if (_firstSpawnTimer <= 0)
        {
            isFirstSpawn = true;
            spawnCounter++;
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        GameObject enemy = ObjectPooling.GetGameObjectFromPool(soEnemy.enemyName, spawnPoint.position, soEnemy.path);
        enemy.transform.SetParent(parent);
        enemy.GetComponent<FlyPathAgent>().FlyPath = flyPath;
        enemies.Add(enemy.GetComponent<EnemyBase>());
    }

    void CheckingSpawn()
    {
        if (!canSpawn) return;
        if (enemies.Count == 0) return;
        int deadEnemyCounter = 0;
        foreach (EnemyBase enemy in enemies)
        {
            if (enemy.IsDead)
            {
                deadEnemyCounter++;
            } 
        }
        if (deadEnemyCounter == quantity)
        {
            foreach (EnemySpawner spawner in nextEnemySpawners)
            {
                spawner.canSpawn = true;
                StopCoroutine(IRepeatChecking());
            }
            if (isTheLastSpawner)
            {
                GameStateManager.Instance.SetState(GameState.Win);
            }
        }
    }

    IEnumerator IRepeatChecking()
    {
        yield return new WaitForSeconds(1);
        CheckingSpawn();
        StartCoroutine(IRepeatChecking());
    }
}
