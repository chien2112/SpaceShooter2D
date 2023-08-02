using UnityEngine;

public class Rockets : Weapon
{
    [SerializeField] Transform shootingPoint2;
    [SerializeField] Transform shootingPoint3;
    [SerializeField] Transform shootingPoint4;
    [SerializeField] Transform shootingPoint5;
    [SerializeField] Transform shootingPoint6;

    protected override void Awake()
    {
        base.Awake();
    }
    public void Shoot(int index)
    {         
        switch (index)
        {
            case 1:
                ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint.position);
                break;
            case 2:
                ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint2.position);
                break;
            case 3:
                ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint3.position);
                break;
            case 4:
                ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint4.position);
                break;
            case 5:
                ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint5.position);
                break;
            case 6:
                ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint6.position);
                break;
        }
        SoundManager.Instance.PlayClip(shootingClip, audioMixerGroup);
    }
}