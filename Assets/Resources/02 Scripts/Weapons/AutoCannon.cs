using UnityEngine;

public class AutoCannon : Weapon
{
    [SerializeField] Transform shootingPoint2;

    public void Shoot(int index)
    {
        if(index == 1)
        {
            GameObject go = ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint.position);
            go.GetComponent<Projectile>().Init(damage, bulletSpeed);
        }
        else
        {
            GameObject go = ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint2.position);
            go.GetComponent<Projectile>().Init(damage, bulletSpeed);
        }
        SoundManager.Instance.PlayClip(shootingClip, audioMixerGroup);
    }
}
