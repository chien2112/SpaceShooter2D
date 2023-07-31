public class BigSpaceGun : Weapon
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void Shoot()
    {
        ObjectPooling.GetGameObjectFromPool(weaponData.bulletName, shootingPoint.position, weaponData.path);
        SoundManager.Instance.PlayClip(shootingClip, audioMixerGroup);
    }
}