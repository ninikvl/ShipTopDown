using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IBulletable
{
    private float _speed = 1f;

    private int _damage = 1;

    private Vector2 _direction = new Vector2(0, 1);
    private Vector2 velocity;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Deal Damage To Collision Object
        DealDamage(collision);

        DisableBullet();
    }


    private void OnEnable()
    {
        velocity = _direction * _speed;
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.deltaTime;

        transform.position = pos;
    }


    private void DealDamage(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(_damage);
        }
    }


    public void Initialize(float bulletSpeed, int bulletDamage, float bulletLifeTime = 2f)
    {
        _speed = bulletSpeed;
        _damage = bulletDamage;

        gameObject.SetActive(true);
        StartCoroutine(BulletLifeRoutine(bulletLifeTime));
    }


    private IEnumerator BulletLifeRoutine(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        DisableBullet();
    }


    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
