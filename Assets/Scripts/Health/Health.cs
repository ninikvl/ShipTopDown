using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _healthPoint;
    public bool isEnemy {  get; private set; }


    public void SetStartHealth(int healthPoint)
    {
        _healthPoint = healthPoint;
    }


    public void TakeDamage(int damage)
    {
        _healthPoint -= damage;
       
        if (_healthPoint <= 0)
            DestroyCharacter();
    }


    private void DestroyCharacter()
    {
        GetComponent<PlayerShip>()?.PlayerDestroyed();
        GetComponent<Enemy>()?.EnemyDestroyed();
    }
}
