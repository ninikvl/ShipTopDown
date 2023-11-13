using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Gun;

public abstract class EnemyGun : MonoBehaviour
{
    [SerializeField] public GunDataSO GunDataSO;
    [SerializeField] public BulletDataSO BulletDataSO;
    [SerializeField] private GameObject _shootPosition;

    private IShootable _lastShootBullet;


    public virtual void InitializeShoot()
    {
        IShootable bullet = (IShootable)PoolManager.Instance.ReuseComponent(BulletDataSO.BulletPrefab, transform.position, Quaternion.identity);
        bullet.Initialize(BulletDataSO.BulletSpeed, BulletDataSO.BulletDamageTier1, BulletDataSO, _shootPosition.transform);
        _lastShootBullet = bullet;
    }

    public virtual void DisableLastShootBullet()
    {
        if(_lastShootBullet != null)
            _lastShootBullet.DisableBullet();
    }

}
