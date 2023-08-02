using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossShootingState : BossBaseState
{
    public override void EnterState(BossStateManager enemy)
    {
        int rand = Random.Range(0, 6);
        switch (rand)
        {
            case 1:
                enemy.SpawnBullet3(45f);
                break;
            case 2:
                enemy.SpawnBullet3(45f);
                break;
            case 3:
                enemy.SpawnBullet3(45f);
                break;
            default:
                enemy.SpawnBullet2();
                break;
        }
        enemy.SwitchState(enemy.idleState);
    }

    public override void UpdateState(BossStateManager enemy)
    {
    }
}
