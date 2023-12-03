using System.Collections;
using UnityEngine;

public class AutoCannon : Gun
{
    private enum ShootTier
    {
        One,
        Two,
        Three
    }

    private const float yBulletOffset = 0.38f;
    private const float xBulletOffset = 0.28f;

    public AutoCannon(TierLevel tierLevel, GunDataSO gunDataSO) : base(tierLevel, gunDataSO)
    {
    }

    public override void InitializeShoot(Transform gunPosition)
    {
        base.InitializeShoot(gunPosition);
    }

    protected override void ShootTierOne(Transform gunPosition)
    {
        Coroutines.StartRoutine(ShootRoutine(gunPosition, ShootTier.One));
    }

    protected override void ShootTierTwo(Transform gunPosition)
    {
        Coroutines.StartRoutine(ShootRoutine(gunPosition, ShootTier.Two));
    }

    protected override void ShootTierThree(Transform gunPosition)
    {
        Coroutines.StartRoutine(ShootRoutine(gunPosition, ShootTier.Three));
    }

    private IEnumerator ShootRoutine(Transform gunPosition, ShootTier shootTier)
    {
        yield return new WaitForSeconds(0.1f);

        Vector3 newGunPosition;
        Vector2 newDirection;

        switch (shootTier)
        {
            case ShootTier.One:

                newGunPosition = new Vector3(gunPosition.position.x + xBulletOffset, gunPosition.position.y + yBulletOffset);
                CreateBullet(newGunPosition);

                newGunPosition = new Vector3(gunPosition.position.x - xBulletOffset, gunPosition.position.y + yBulletOffset);
                CreateBullet(newGunPosition);

                break;
            case ShootTier.Two:

                newGunPosition = new Vector3(gunPosition.position.x + xBulletOffset, gunPosition.position.y + yBulletOffset);
                CreateBullet(newGunPosition);

                newGunPosition = new Vector3(gunPosition.position.x - xBulletOffset, gunPosition.position.y + yBulletOffset);
                CreateBullet(newGunPosition);

                break;
            case ShootTier.Three:

                newGunPosition = new Vector3(gunPosition.position.x + xBulletOffset, gunPosition.position.y + yBulletOffset);
                CreateBullet(newGunPosition);

                newGunPosition = new Vector3(gunPosition.position.x - xBulletOffset, gunPosition.position.y + yBulletOffset);
                CreateBullet(newGunPosition);

                newGunPosition = new Vector3(gunPosition.position.x - xBulletOffset, gunPosition.position.y + yBulletOffset);
                newDirection = new Vector2(-0.5f, 1f);
                CreateBullet(newGunPosition, newDirection);

                newGunPosition = new Vector3(gunPosition.position.x + xBulletOffset, gunPosition.position.y + yBulletOffset);
                newDirection = new Vector2(0.5f, 1f);
                CreateBullet(newGunPosition, newDirection);

                break;
            default:
                break;
        }
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
