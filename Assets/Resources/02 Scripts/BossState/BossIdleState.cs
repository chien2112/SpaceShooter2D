using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossIdleState : BossBaseState
{
    int rand;
    float counter;
    float timeToSwitchState;
    public override void EnterState(BossStateManager enemy)
    {
        timeToSwitchState = Random.Range(1, 3);
        counter = timeToSwitchState;
    }

    public override void UpdateState(BossStateManager enemy)
    {
        if(enemy.enemyBase.CurrentHp < enemy.enemyBase.Hp*0.45f)
        {
            enemy.enemyBase.GetComponent<SpriteRenderer>().sprite = enemy.enemyBase.Phase2Sprite;
            enemy.SwitchState(enemy.phase2State);
        }
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            rand = Random.Range(0, 7);
            switch (rand)
            {
                default:
                    enemy.SwitchState(enemy.shootingState);
                    return;
                case 5:
                    enemy.SwitchState(enemy.approachingState);
                    return;
            }
        }
    }
}