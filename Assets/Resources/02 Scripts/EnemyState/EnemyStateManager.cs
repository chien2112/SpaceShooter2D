using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyBaseState currentState;
    public EnemyMovingState movingState = new EnemyMovingState();
    public EnemyApproachingState approachingState = new EnemyApproachingState();
    public EnemyShootingState shootingState = new EnemyShootingState();

    [HideInInspector] public Transform player;
    [HideInInspector] public EnemyBase enemyBase;
    [HideInInspector] public FlyPathAgent flyPathAgent;

    // Start is called before the first frame update
    void Start()
    {
        player = UnityEngine.GameObject.FindGameObjectWithTag("Player").transform;

        enemyBase = GetComponent<EnemyBase>();
        flyPathAgent = GetComponent<FlyPathAgent>();    

        currentState = movingState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    //Switch state
    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    #region SHOOTING STATE
    public void SpawnBullet()
    {
        var bullet = ObjectPooling.GetGameObjectFromPool(enemyBase.EnemyBulletPrefab.name, transform.position, "01 Prefabs/Enemy/Bullet/EnemyBullet_1");
        bullet.transform.eulerAngles = new Vector3(0, 0, -90);
        float bulletSpeed = enemyBase.EnemyBulletPrefab.GetComponent<EnemyBullet>().Speed;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1).normalized * bulletSpeed;
    }
    public void SpawnBullet2()
    {
        var bullet = ObjectPooling.GetGameObjectFromPool(enemyBase.EnemyBulletPrefab.name, transform.position, "01 Prefabs/Enemy/Bullet/EnemyBullet_1");
        var bullet2 = ObjectPooling.GetGameObjectFromPool(enemyBase.EnemyBulletPrefab.name, transform.position, "01 Prefabs/Enemy/Bullet/EnemyBullet_1");
        var bullet3 = ObjectPooling.GetGameObjectFromPool(enemyBase.EnemyBulletPrefab.name, transform.position, "01 Prefabs/Enemy/Bullet/EnemyBullet_1");

        bullet.transform.eulerAngles = new Vector3(0, 0, -90);
        bullet2.transform.eulerAngles = new Vector3(0, 0, -100);
        bullet3.transform.eulerAngles = new Vector3(0, 0, -70);

        float bulletSpeed = enemyBase.EnemyBulletPrefab.GetComponent<EnemyBullet>().Speed;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1).normalized * bulletSpeed;
        bullet2.GetComponent<Rigidbody2D>().velocity = new Vector3(-0.15f, -0.5f).normalized * bulletSpeed;
        bullet3.GetComponent<Rigidbody2D>().velocity = new Vector3(0.15f, -0.5f).normalized * bulletSpeed;
    }
    public void SpawnBullet3(float angle)
    {
        float a = angle;
        float bulletSpeed = enemyBase.EnemyBulletPrefab.GetComponent<EnemyBullet>().Speed;
        for (int i = 0; i <= 10; i++)
        {
            var bullet = ObjectPooling.GetGameObjectFromPool(enemyBase.EnemyBulletPrefab.name, transform.position, "01 Prefabs/Enemy/Bullet/EnemyBullet_1");
            float dirX = Mathf.Sin((a * Mathf.PI) / 180);
            float dirY = Mathf.Cos((a * Mathf.PI) / 180);

            Vector2 bulletDir = new Vector3(dirX, dirY).normalized * bulletSpeed;

            bullet.transform.eulerAngles = new Vector3(0, 0, 90 - a);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDir;
            
            a += 36;
        }
    }
    public void SpawnBullet4(float timeDelay, float angle, int repeatCount)
    {
        SpawnBullet3(0);
        StartCoroutine(ISpawnBullet3Delay(timeDelay, angle, repeatCount));
    }
    IEnumerator ISpawnBullet3Delay(float timeDelay, float angle, int repeatCount)
    {
        for(int i = 0; i<= repeatCount; i++)
        {
            yield return new WaitForSeconds(timeDelay);
            SpawnBullet3((angle+ angle*i));
        }
    }

    #endregion
}
