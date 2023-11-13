using System.Collections;
using UnityEngine;
using static Gun;

public class AutoCannon : Gun
{
    private bool _isFirstShoot = true;

    public AutoCannon(TierLevel tierLevel, GunDataSO gunDataSO) : base(tierLevel, gunDataSO)
    {
    }

    public override void InitializeShoot(Vector3 gunPosition)
    {
        base.InitializeShoot(gunPosition);
    }

    protected override void ShootTierOne(Vector3 gunPosition)
    {
        Vector3 rightGunPosition = new Vector3(gunPosition.x + 0.27f, gunPosition.y + 0.38f);

        IShootable bullet = (IShootable)PoolManager.Instance.ReuseComponent(BulletDataSO.BulletPrefab, rightGunPosition, Quaternion.identity);
        bullet.Initialize(BulletDataSO.BulletSpeed, _bulletDamage, BulletDataSO);

        rightGunPosition = new Vector3(gunPosition.x - 0.28f, gunPosition.y + 0.38f);

        bullet = (IShootable)PoolManager.Instance.ReuseComponent(BulletDataSO.BulletPrefab, rightGunPosition, Quaternion.identity);
        bullet.Initialize(BulletDataSO.BulletSpeed, _bulletDamage, BulletDataSO);
    }
        
    protected override void ShootTierTwo(Vector3 gunPosition)
    {
        IShootable bullet = (IShootable)PoolManager.Instance.ReuseComponent(BulletDataSO.BulletPrefab, gunPosition, Quaternion.identity);
        bullet.Initialize(BulletDataSO.BulletSpeed, _bulletDamage, BulletDataSO);
    }

    protected override void ShootTierThree(Vector3 gunPosition)
    {

    }
    public override void UpTierLevel()
    {
        base.UpTierLevel();
    }
}
