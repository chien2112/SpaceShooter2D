using UnityEngine;

public class EnemyApproachingState : EnemyBaseState
{
    Vector2 playerPos;
    Vector2 endPos;
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.flyPathAgent.enabled = false;
        playerPos = enemy.player.position;
        if (playerPos.y < enemy.enemyBase.transform.position.y)
        {
            endPos = new Vector2(playerPos.x, playerPos.y - 1f);
        }
        else
        {
            endPos = playerPos;
        }
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.enemyBase.transform.position, endPos, enemy.enemyBase.EnemySpeed * Time.deltaTime);
        var distance = Vector2.Distance(endPos, enemy.enemyBase.transform.position);
        if (distance <= 0.1f)
        {
            enemy.flyPathAgent.enabled = true;
            enemy.SwitchState(enemy.movingState);
        }
    }
}
