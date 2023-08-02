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
            ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint.position);
        }
        else
        {
            ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint.position);
        }
        SoundManager.Instance.PlayClip(shootingClip, audioMixerGroup);
    }
}
