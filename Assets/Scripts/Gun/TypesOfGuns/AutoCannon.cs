using UnityEngine;
using static Gun;

public class AutoCannon : Gun
{
    public AutoCannon(TierLevel tierLevel, GunDataSO gunDataSO) : base(tierLevel, gunDataSO)
    {
    }


    public override void InitializeShoot(Vector3 gunPosition)
    {
        base.InitializeShoot(gunPosition);
    }


    protected override void ShootTierOne(Vector3 gunPosition)
    {
        IBulletable bullet = (IBulletable)PoolManager.Instance.ReuseComponent(GunDataSO.BulletPrefab, gunPosition, Quaternion.identity);
        bullet.Initialize(GunDataSO.BulletSpeed, _bulletDamage);
    }


    protected override void ShootTierTwo(Vector3 gunPosition)
    {
        IBulletable bullet = (IBulletable)PoolManager.Instance.ReuseComponent(GunDataSO.BulletPrefab, gunPosition, Quaternion.identity);
        bullet.Initialize(GunDataSO.BulletSpeed, _bulletDamage);
    }


    protected override void ShootTierThree(Vector3 gunPosition)
    {

    }

    public override void UpTierLevel()
    {
        base.UpTierLevel();
    }
}
