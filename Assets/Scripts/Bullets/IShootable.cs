
using UnityEngine;

public interface IShootable
{
    public void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, float bulletLifeTime = 2f);
    public void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, GameObject weaponObject, float bulletLifeTime = 2f);
}
