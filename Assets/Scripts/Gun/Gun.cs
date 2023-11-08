using UnityEngine;

public class Gun : IGunable
{
    public enum TierLevel
    {
        First,
        Second,
        Third
    }

    private TierLevel _tierLevel;

    public GunDataSO GunDataSO { get; private set; }

    public Gun(TierLevel tierLevel, GunDataSO gunDataSO)
    {
        this._tierLevel = tierLevel;
        GunDataSO = gunDataSO;
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

    protected virtual void ShootTierOne(Vector3 gunPosition)
    {
    }

    protected virtual  void ShootTierTwo(Vector3 gunPosition)
    {
    }

    protected virtual void ShootTierThree(Vector3 gunPosition)
    {
    }

    public void UpTierLevel()
    {
        if (_tierLevel != TierLevel.Third)
        {
            _tierLevel++;
        }
    }
}
