
using UnityEngine;

public interface IShootable
{
    public void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO);
    public void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, Transform shootPosition);
    public void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, Vector2 direction);
    public void DisableBullet();
}
