using System;
using System.Collections;
using UnityEngine;

public class CommonBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void BulletMovement()
    {
        base.BulletMovement();
    }

    public override void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO)
    {
        base.Initialize(bulletSpeed, bulletDamage, bulletDataSO);
        _animator.CrossFade(Settings.CommonBulletAnimation, 0, 0);
    }

    public override void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, Vector2 direction)
    {
        base.Initialize(bulletSpeed, bulletDamage, bulletDataSO, direction);
        _animator.CrossFade(Settings.CommonBulletAnimation, 0, 0);
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
