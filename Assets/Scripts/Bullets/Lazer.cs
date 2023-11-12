using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : Bullet, IShootable
{
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void FixedUpdate()
    {
        BulletMovement();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }


    public new void BulletMovement()
    {
        transform.position = _weaponObject.transform.position;
    }


    public override void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, GameObject weaponObject, float bulletLifeTime = 2)
    {
        base.Initialize(bulletSpeed, bulletDamage, bulletDataSO, weaponObject, bulletLifeTime);
        _animator.CrossFade(Settings.LazerAnimation, 0, 0);
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
