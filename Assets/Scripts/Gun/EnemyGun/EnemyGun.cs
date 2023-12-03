using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGun : MonoBehaviour
{
    [SerializeField] public BulletDataSO BulletDataSO;
    [SerializeField] protected GameObject _shootPosition;

    protected Enemy _enemy;

    protected IShootable _lastShootBullet;

    protected virtual void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public virtual void InitializeShoot()
    {
        if (gameObject != null)
        {
            IShootable bullet = (IShootable)PoolManager.Instance.ReuseComponent(BulletDataSO.BulletPrefab, transform.position, Quaternion.identity);
            bullet.Initialize(BulletDataSO.BulletSpeedTier1, BulletDataSO.BulletDamageTier1, BulletDataSO, _shootPosition.transform);

            _lastShootBullet = bullet;
        }
    }

    public virtual void DisableLastShootBullet()
    {
        if(_lastShootBullet != null)
            _lastShootBullet.DisableBullet();
    }
}
