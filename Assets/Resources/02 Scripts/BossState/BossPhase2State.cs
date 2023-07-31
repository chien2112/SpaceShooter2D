using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2State : BossBaseState
{
    float counter;
    float timeToSwitchState;
    public override void EnterState(BossStateManager enemy)
    {
        timeToSwitchState = 5f;
        counter = timeToSwitchState;
    }

    public override void UpdateState(BossStateManager enemy)
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            enemy.SwitchState(enemy.bulletHellState);
        }
    }
}
