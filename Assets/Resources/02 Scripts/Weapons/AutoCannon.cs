using UnityEngine;

public class AutoCannon : Weapon
{
    [SerializeField] Transform shootingPoint2;


    protected override void Awake()
    {
        base.Awake();
    }
    public void Shoot(int index)
    {
        if(index == 1)
        {
            ObjectPooling.GetGameObjectFromPool(weaponData.bulletName, shootingPoint.position, weaponData.path);
        }
        else
        {
            ObjectPooling.GetGameObjectFromPool(weaponData.bulletName, shootingPoint2.position, weaponData.path);
        }
        SoundManager.Instance.PlayClip(shootingClip, audioMixerGroup);
    }
}
