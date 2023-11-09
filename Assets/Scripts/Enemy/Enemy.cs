using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AnimateEnemy))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyDataSO _enemyDataSO;

    private Health _health;
    private AnimateEnemy _animateEnemy;
    private PolygonCollider2D _polygonCollider;
    
    public Animator Animator { get; private set; }


    private void Awake()
    {
        _health = GetComponent<Health>();
        _animateEnemy = GetComponent<AnimateEnemy>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
        Animator = GetComponent<Animator>();

        _health.SetStartHealth(_enemyDataSO.HealthPoint);
    }

    public void EnemyDestroyed()
    {
        _animateEnemy.DestroyAnimation();
        _polygonCollider.enabled = false;

        AnimatorStateInfo animatorStateInfo = Animator.GetCurrentAnimatorStateInfo(0);

        StartCoroutine(AD(animatorStateInfo));
    }

    private IEnumerator AD(AnimatorStateInfo animatorStateInfo)
    {
        yield return new WaitForSeconds(animatorStateInfo.length);

        Destroy(gameObject);
    }

}
