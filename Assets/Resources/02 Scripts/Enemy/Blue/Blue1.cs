using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue1 : EnemyBase
{
    public override void DropItem()
    {
        int rand = Random.Range(0, 4);
        float randX = Random.Range(-0.1f, 0.1f);
        float randY = Random.Range(-0.1f, 0.1f);

        Vector3 spawnPoint = new Vector3(transform.position.x + randX, transform.position.y + randY, 0);

        switch (rand)
        {
            case 1:
                ObjectPooling.GetGameObjectFromPool(items[0], spawnPoint);
                break;
            default:
                ObjectPooling.GetGameObjectFromPool(items[1], spawnPoint);
                break;
        }
        
    }

}
