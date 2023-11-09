using UnityEngine;

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
        base.ShootTierOne(gunPosition);

        IBulletable bullet = (IBulletable)PoolManager.Instance.ReuseComponent(GunDataSO.BulletPrefab, gunPosition, Quaternion.identity);
        bullet.Initialize(GunDataSO.BulletSpeed, GunDataSO.BulletDamage);
    }


    protected override void ShootTierTwo(Vector3 gunPosition)
    {
        base.ShootTierTwo(gunPosition);
    }


    protected override void ShootTierThree(Vector3 gunPosition)
    {
        base.ShootTierThree(gunPosition);
    }
}
