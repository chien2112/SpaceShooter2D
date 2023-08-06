using UnityEngine;

public class Rockets : Weapon
{
    [SerializeField] Transform shootingPoint2;
    [SerializeField] Transform shootingPoint3;
    [SerializeField] Transform shootingPoint4;
    [SerializeField] Transform shootingPoint5;
    [SerializeField] Transform shootingPoint6;
    public void Shoot(int index)
    {         
        switch (index)
        {
            case 1:
                GameObject go = ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint.position);
                go.GetComponent<Projectile>().Init(damage, bulletSpeed);
                break;
            case 2:
                GameObject go1 = ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint2.position);
                go1.GetComponent<Projectile>().Init(damage, bulletSpeed);
                break;
            case 3:
                GameObject go2 = ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint3.position);
                go2.GetComponent<Projectile>().Init(damage, bulletSpeed);
                break;
            case 4:
                GameObject go3 = ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint4.position);
                go3.GetComponent<Projectile>().Init(damage, bulletSpeed);
                break;
            case 5:
                GameObject go4 = ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint5.position);
                go4.GetComponent<Projectile>().Init(damage, bulletSpeed);
                break;
            case 6:
                GameObject go5 = ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint6.position);
                go5.GetComponent<Projectile>().Init(damage, bulletSpeed);
                break;
        }
        SoundManager.Instance.PlayClip(shootingClip, audioMixerGroup);
    }
}