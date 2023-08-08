using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue2 : EnemyBase
{
    public override void DropItem()
    {
        int rand = Random.Range(0, 30);
        float randX = Random.Range(-0.1f, 0.1f);
        float randY = Random.Range(-0.1f, 0.1f);

        Vector3 spawnPoint = new Vector3(transform.position.x + randX, transform.position.y + randY, 0);
        switch (rand)
        {
            case 10:
                ObjectPooling.GetGameObjectFromPool(items[0], spawnPoint);
                break;
            case 15:
                foreach (var item in items)
                {
                    ObjectPooling.GetGameObjectFromPool(item, spawnPoint);
                }
                break;
            default:
                ObjectPooling.GetGameObjectFromPool(items[1], spawnPoint);
                break;
        }
    }
}

