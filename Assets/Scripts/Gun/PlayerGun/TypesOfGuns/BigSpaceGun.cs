using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpaceGun : Gun
{
    public BigSpaceGun(TierLevel tierLevel, GunDataSO gunDataSO) : base(tierLevel, gunDataSO)
    {
    }

    public override void InitializeShoot(Transform gunPosition)
    {
        base.InitializeShoot(gunPosition);
    }

    protected override void ShootTierOne(Transform gunPosition)
    {
        CreateBullet(new Vector3(gunPosition.position.x, gunPosition.position.y));
    }

    protected override void ShootTierThree(Transform gunPosition)
    {
        throw new System.NotImplementedException();
    }

    protected override void ShootTierTwo(Transform gunPosition)
    {
        throw new System.NotImplementedException();
    }

    public override void UpTierLevel()
    {
        base.UpTierLevel();
    }

    protected override void CreateBullet(Vector3 newGunPosition)
    {
        base.CreateBullet(newGunPosition);
    }

    protected override void CreateBullet(Vector3 newGunPosition, Vector2 newDirection)
    {
        base.CreateBullet(newGunPosition, newDirection);
    }
}
