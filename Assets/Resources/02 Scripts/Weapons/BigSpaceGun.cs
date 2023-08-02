public class BigSpaceGun : Weapon
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void Shoot()
    {
        ObjectPooling.GetGameObjectFromPool(weaponData.projectilePrefab, shootingPoint.position);
        SoundManager.Instance.PlayClip(shootingClip, audioMixerGroup);
    }
}