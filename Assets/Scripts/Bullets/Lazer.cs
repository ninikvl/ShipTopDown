using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : Bullet, IShootable
{
    protected override void FixedUpdate()
    {
        BulletMovement();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision);
    }

    public new void BulletMovement()
    {
        if (_shootPosition != null)
            transform.position = _shootPosition.transform.position;
        else
            DisableBullet();
    }

    public override void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, Transform shootPosition)
    {
        base.Initialize(bulletSpeed, bulletDamage, bulletDataSO, shootPosition);
        _animator.CrossFade(Settings.LazerAnimation, 0, 0);
    }

    protected override void DealDamage(Collider2D collision)
    {
        base.DealDamage(collision);
    }

    public override void DisableBullet()
    {
        base.DisableBullet();
    }
}
