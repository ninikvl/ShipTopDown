using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Gun;

public abstract class EnemyGun : MonoBehaviour
{
    [SerializeField] private GunDataSO _gunDataSO;
    [SerializeField] private BulletDataSO _bulletDataSO;


    public virtual void InitializeShoot()
    {
        IShootable bullet = (IShootable)PoolManager.Instance.ReuseComponent(_bulletDataSO.BulletPrefab, transform.position, Quaternion.identity);
        bullet.Initialize(_bulletDataSO.BulletSpeed, _bulletDataSO.BulletDamageTier1, _bulletDataSO, this.gameObject);
    }


}
