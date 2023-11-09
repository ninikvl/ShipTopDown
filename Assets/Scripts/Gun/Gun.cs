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

    public GunDataSO GunDataSO { get; private set; }

    protected float _bulletSpawnInterval;

    protected int _bulletDamage;

    public Gun(TierLevel tierLevel, GunDataSO gunDataSO)
    {
        this._tierLevel = tierLevel;
        GunDataSO = gunDataSO;

        _bulletSpawnInterval = gunDataSO.BulletSpawnIntervalTier1;
        _bulletDamage = gunDataSO.BulletDamageTier1;
    }

    public virtual void InitializeShoot(Vector3 gunPosition)
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
                    _bulletDamage = GunDataSO.BulletDamageTier2;
                    break;
                case TierLevel.Third:
                    _bulletSpawnInterval = GunDataSO.BulletSpawnIntervalTier3;
                    _bulletDamage = GunDataSO.BulletDamageTier3;
                    break;
                default:
                    break;
            }
        }
    }

    protected abstract void ShootTierOne(Vector3 gunPosition);

    protected abstract void ShootTierTwo(Vector3 gunPosition);

    protected abstract void ShootTierThree(Vector3 gunPosition);
}
