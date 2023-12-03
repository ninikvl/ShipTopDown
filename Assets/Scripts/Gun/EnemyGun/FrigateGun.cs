using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrigateGun : EnemyGun
{
    public override void DisableLastShootBullet()
    {
        base.DisableLastShootBullet();
    }

    public override void InitializeShoot()
    {
        Coroutines.StartRoutine(FrigateShoot());
    }

    private IEnumerator FrigateShoot()
    {
        yield return new WaitForEndOfFrame();

        InitializeBullet(new(transform.position.x - 0.47f, transform.position.y + 0.12f));
        InitializeBullet(new(transform.position.x + 0.47f, transform.position.y + 0.12f));

        yield return new WaitForSeconds(_enemy.Animator.GetCurrentAnimatorStateInfo(0).length / 2);

        InitializeBullet(new(transform.position.x - 0.25f, transform.position.y - 0.18f));
        InitializeBullet(new(transform.position.x + 0.25f, transform.position.y - 0.18f));
    }

    private void InitializeBullet(Vector2 newGunPosition)
    {
        IShootable bullet = (IShootable)PoolManager.Instance.ReuseComponent(BulletDataSO.BulletPrefab, newGunPosition, Quaternion.identity);
        bullet.Initialize(BulletDataSO.BulletSpeedTier1, BulletDataSO.BulletDamageTier1, BulletDataSO, Vector2.down);
    }
}
