using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnought : EnemyAI
{
    private float _yAnchorPosition = 10f;

    private bool _isHoldLazer = false;
    private bool _isStopAI = false;

    private DreadnoughtGun _dreadnoughtGun;
    private Enemy _enemy;


    private void Awake()
    {
        _dreadnoughtGun = GetComponent<DreadnoughtGun>();
        _enemy = GetComponent<Enemy>();
        _isStopAI = false;
    }

    private void Update()
    {
        if (_isStopAI)
            return;

        if (IsShootPossible() && !_isHoldLazer)
        {
            _enemy.StartEnemyAttack();
            StartCoroutine(HoldLazerRoutine());
        }
    }

    private void FixedUpdate()
    {
        if (_isStopAI)
            return;

        float offset = PlayerShip.Instance.GetPlayerPositon().x - transform.position.x;

        if (offset > 0.2f || offset < -0.2f)
            MoveToPosition(new Vector2(PlayerShip.Instance.GetPlayerPositon().x, transform.position.y), transform.position, 1f);
    }

    private void Start()
    {
        ActivateAI();
    }


    public override void ActivateAI()
    {
        base.ActivateAI();

        StartCoroutine(MoveToAnchorVerticalPosition());
    }

    public override void DeactivateAI()
    {
        base.DeactivateAI();

        _isStopAI = true;

        StopAllCoroutines();

        _dreadnoughtGun.DisableLastShootBullet();
    }

    private bool IsShootPossible()
    {
        if (transform.position.y <= _yAnchorPosition && !_enemy.IsShooting && !_enemy.IsDestroying) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator HoldLazerRoutine()
    {
        _isHoldLazer = true;
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(_enemy.Animator.GetCurrentAnimatorStateInfo(0).length);

        if (_enemy.IsDestroying)
            yield return null;

        _dreadnoughtGun.InitializeShoot();
        yield return new WaitForSeconds(_dreadnoughtGun.BulletDataSO.BulletLifeTime);
        _isHoldLazer = false;
    }

    private IEnumerator MoveToAnchorVerticalPosition()
    {
        while (transform.position.y > _yAnchorPosition) 
        {
            transform.position = (Vector2)transform.position - new Vector2(0, 1) * Time.deltaTime * 1f;
            yield return new WaitForFixedUpdate();
        }
    }

    protected override void MoveToPosition(Vector2 movePosition, Vector2 currentPosition, float moveSpeed)
    {
        base.MoveToPosition(movePosition, currentPosition, moveSpeed);
    }
}
