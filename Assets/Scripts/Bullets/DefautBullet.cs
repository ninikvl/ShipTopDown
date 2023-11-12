using System;
using System.Collections;
using UnityEngine;

public class DefautBullet : Bullet
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


    public override void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, float bulletLifeTime = 2)
    {
        base.Initialize(bulletSpeed, bulletDamage, bulletDataSO, bulletLifeTime);
    }


    protected override void DealDamage(Collider2D collision)
    {
        base.DealDamage(collision);
    }


    protected override void DisableBullet()
    {
        base.DisableBullet();
    }
}
