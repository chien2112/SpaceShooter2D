using UnityEngine;

public class EnemyShootingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        //enemy.SpawnBullet4(0.3f, 45f, 5);
        
        switch (enemy.enemyBase.EnemyName)
        {
            case "Blue 1":
                enemy.SpawnBullet();
                break;
            case "Blue 2":
                enemy.SpawnBullet2();
                break;
        }
        enemy.SwitchState(enemy.movingState);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
    }
}
