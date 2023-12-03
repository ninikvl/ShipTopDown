using UnityEngine;

public abstract class Gun : IGunable
{
    public enum TierLevel
    {
        First,
        Second,
        Third
    }

    protected TierLevel _tierLevel;

    protected int _bulletDamage;
    protected int _bulletSpeed;

    protected float _bulletSpawnInterval;

    public GunDataSO GunDataSO { get; private set; }
    public BulletDataSO BulletDataSO { get; private set; }


    public Gun(TierLevel tierLevel, GunDataSO gunDataSO)
    {
        GunDataSO = gunDataSO;
        BulletDataSO = gunDataSO.BulletDataSO;

        _tierLevel = tierLevel;
        _bulletSpawnInterval = gunDataSO.BulletSpawnIntervalTier1;
        _bulletDamage = gunDataSO.BulletDataSO.BulletDamageTier1;
        _bulletSpeed = gunDataSO.BulletDataSO.BulletSpeedTier1;
    }

    public virtual void InitializeShoot(Transform gunPosition)
    {
        switch (_tierLevel)
        {
            case TierLevel.First:
                ShootTierOne(gunPosition);
                break;
            case TierLevel.Second:
                ShootTierTwo(gunPosition);
                break;
            case TierLevel.Third:
                ShootTierThree(gunPosition);
                break;
            default:
                break;
        }
    }

    public float GetBulletSpawnInterval()
    {
        return _bulletSpawnInterval;
    }

    public virtual void UpTierLevel()
    {
        if (_tierLevel != TierLevel.Third)
        {
            _tierLevel++;

            switch (_tierLevel)
            {
                case TierLevel.Second:
                    _bulletSpawnInterval = GunDataSO.BulletSpawnIntervalTier2;
                    _bulletDamage = BulletDataSO.BulletDamageTier2;
                    _bulletSpeed = BulletDataSO.BulletSpeedTier2;
                    break;
                case TierLevel.Third:
                    _bulletSpawnInterval = GunDataSO.BulletSpawnIntervalTier3;
                    _bulletDamage = BulletDataSO.BulletDamageTier3;
                    _bulletSpeed = BulletDataSO.BulletSpeedTier3;
                    break;
                default:
                    break;
            }
        }
    }

    protected virtual void CreateBullet(Vector3 newGunPosition)
    {
        IShootable bullet = (IShootable)PoolManager.Instance.ReuseComponent(BulletDataSO.BulletPrefab, newGunPosition, Quaternion.identity);
        bullet.Initialize(_bulletSpeed, _bulletDamage, BulletDataSO);
    }

    protected virtual void CreateBullet(Vector3 newGunPosition, Vector2 newDirection)
    {
        IShootable bullet = (IShootable)PoolManager.Instance.ReuseComponent(BulletDataSO.BulletPrefab, newGunPosition, Quaternion.identity);
        bullet.Initialize(_bulletSpeed, _bulletDamage, BulletDataSO, newDirection);
    }

    protected abstract void ShootTierOne(Transform gunPosition);

    protected abstract void ShootTierTwo(Transform gunPosition);

    protected abstract void ShootTierThree(Transform gunPosition);
}
