using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsProjectile : Projectile
{
    protected override void OnEnable()
    {
        base.OnEnable();
        rb.gravityScale = 0;
    }
    private void Update()
    {
        rb.gravityScale -= 3f*Time.deltaTime;
    }

}
