using UnityEngine;

public class EnemyMovingState : EnemyBaseState
{
    int rand;
    float counter;
    float timeToSwitchState;
    public override void EnterState(EnemyStateManager enemy)
    {
        timeToSwitchState = Random.Range(3, 6);
        counter = timeToSwitchState;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            //enemy.SwitchState(enemy.shootingState);
            rand = Random.Range(0, 7);
            switch (rand)
            {
                default:
                    enemy.SwitchState(enemy.shootingState);
                    break;
                case 6:
                    enemy.SwitchState(enemy.approachingState);
                    break;
            }
        }
    }
}
