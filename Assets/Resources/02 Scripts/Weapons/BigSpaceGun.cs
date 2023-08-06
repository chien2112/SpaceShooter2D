using UnityEngine;

public class BigSpaceGun : Weapon
{
    public void Shoot()
    {
        GameObject go = ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint.position);
        go.GetComponent<Projectile>().Init(damage, bulletSpeed);
        SoundManager.Instance.PlayClip(shootingClip, audioMixerGroup);
    }
}