using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Bullet : MonoBehaviour, IShootable
{
    protected float _speed;
    protected int _damage;
    protected Vector2 _direction = new Vector2(0, 1);
    protected Vector2 _velocity;
    protected BulletDataSO _bulletDataSO;
    protected GameObject _weaponObject;


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision);

        DisableBullet();
    }


    protected virtual void FixedUpdate()
    {
        BulletMovement();
    }

    public virtual void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, float bulletLifeTime = 2)
    {
        _speed = bulletSpeed;
        _damage = bulletDamage;
        _velocity = _direction * _speed;

        gameObject.SetActive(true);
        StartCoroutine(BulletLifeRoutine(bulletLifeTime));
    }

    public virtual void Initialize(float bulletSpeed, int bulletDamage, BulletDataSO bulletDataSO, GameObject weaponObject, 
        float bulletLifeTime = 2)
    {
        _speed = bulletSpeed;
        _damage = bulletDamage;
        _velocity = _direction * _speed;
        _weaponObject = weaponObject;

        gameObject.SetActive(true);
        StartCoroutine(BulletLifeRoutine(bulletLifeTime));
    }


    public virtual void BulletMovement()
    {
        Vector2 pos = transform.position;
        pos += _velocity * Time.deltaTime;
        transform.position = pos;
    }


    private IEnumerator BulletLifeRoutine(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        DisableBullet();
    }


    protected virtual void DealDamage(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(_damage);
        }
    }


    protected virtual void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
