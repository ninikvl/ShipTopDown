using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AnimateEnemy))]
public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemyDataSO EnemyDataSO;

    private Health _health;
    private EnemyAI _enemyAI;
    private AnimateEnemy _animateEnemy;
    
    private PolygonCollider2D _polygonCollider;

    public Animator Animator { get; private set; }

    public bool IsShooting {  get; private set; }
    public bool IsDestroying { get; private set; }
    

    private void Awake()
    {
        _health = GetComponent<Health>();
        _animateEnemy = GetComponent<AnimateEnemy>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _enemyAI = GetComponent<EnemyAI>();
        Animator = GetComponent<Animator>();

        IsDestroying = false;
        IsShooting = false;

        _health.SetStartHealth(EnemyDataSO.HealthPoint);
    }

    public void StartEnemyDestroy()
    {
        if (IsDestroying)
            return;

        IsDestroying = true;

        StopAllCoroutines();
        _enemyAI.DeactivateAI();
        _polygonCollider.enabled = false;

        _animateEnemy.DestroyAnimation();

        StartCoroutine(DestroyEnemyRoutine());
    }

    public void StartEnemyAttack()
    {
        if (IsShooting || IsDestroying)
            return;

        IsShooting = true;
        _animateEnemy.AttackAnimation();

        StartCoroutine(ShootEnemyRoutine());
    }

    private IEnumerator ShootEnemyRoutine()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorStateInfo(0).length);
        IsShooting = false;
        _animateEnemy.MovingAnimation();
    }

    private IEnumerator DestroyEnemyRoutine()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorStateInfo(0).length);
        DestroyImmediate(gameObject);
    }
}
