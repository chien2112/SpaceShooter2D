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
                ObjectPooling.GetGameObjectFromPool(weaponData.bulletName, shootingPoint.position, weaponData.path);
                break;
            case 2:
                ObjectPooling.GetGameObjectFromPool(weaponData.bulletName, shootingPoint2.position, weaponData.path);
                break;
            case 3:
                ObjectPooling.GetGameObjectFromPool(weaponData.bulletName, shootingPoint3.position, weaponData.path);
                break;
            case 4:
                ObjectPooling.GetGameObjectFromPool(weaponData.bulletName, shootingPoint4.position, weaponData.path);
                break;
            case 5:
                ObjectPooling.GetGameObjectFromPool(weaponData.bulletName, shootingPoint5.position, weaponData.path);
                break;
            case 6:
                ObjectPooling.GetGameObjectFromPool(weaponData.bulletName, shootingPoint6.position, weaponData.path);
                break;
        }
        SoundManager.Instance.PlayClip(shootingClip, audioMixerGroup);
    }
}