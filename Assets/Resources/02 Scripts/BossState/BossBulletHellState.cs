using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletHellState : BossBaseState
{
    public override void EnterState(BossStateManager enemy)
    {
        enemy.SpawnBullet4(0.5f, 45, 7);
        enemy.SwitchState(enemy.phase2State);
    }

    public override void UpdateState(BossStateManager enemy)
    {
    }
}
