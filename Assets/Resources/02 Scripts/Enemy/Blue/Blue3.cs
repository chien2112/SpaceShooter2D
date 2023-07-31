using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue3 : EnemyBase
{
    public override void DropItem()
    {
        foreach (var item in items)
        {
            float randX = Random.Range(-0.1f, 0.1f);
            float randY = Random.Range(-0.1f, 0.1f);
            Vector3 spawnPoint = new Vector3(transform.position.x + randX, transform.position.y + randY, 0);

            ObjectPooling.GetGameObjectFromPool(item, spawnPoint);
        }
    }
}
