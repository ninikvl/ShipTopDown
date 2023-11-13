using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEnemy : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void DestroyAnimation()
    {
        _enemy.Animator.CrossFade(Settings.EnemyDestruction,0,0);
    }

    public void AttackAnimation()
    {
        _enemy.Animator.CrossFade(Settings.EnemyShooting, 0, 0);
    }

    public void MovingAnimation()
    {
        _enemy.Animator.CrossFade(Settings.EnemyMoving, 0, 0);
    }
}
