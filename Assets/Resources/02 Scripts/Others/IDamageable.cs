using UnityEngine;

public interface IDamageable
{
    abstract void TakeHit(float damage, Vector2 hitPoint, Vector2 hitDirection);

    abstract void TakeDamage(float damage);
}