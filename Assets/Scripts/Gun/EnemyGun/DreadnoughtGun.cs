using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadnoughtGun : EnemyGun
{
    private bool _isHoldLazer;

    private void Update()
    {
        if(_enemy.IsDestroying)
        {
            StopAllCoroutines();
            DisableLastShootBullet();
        }
    }

    public override void InitializeShoot()
    {
        base.InitializeShoot();
    }

    public void StartDreadnoughtShoot()
    {
        if (gameObject != null)
            StartCoroutine(HoldLazerRoutine());
    }

    private IEnumerator HoldLazerRoutine()
    {
        _isHoldLazer = true;
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(_enemy.Animator.GetCurrentAnimatorStateInfo(0).length);

        if (_enemy.IsDestroying)
            yield return null;

        InitializeShoot();
        yield return new WaitForSeconds(BulletDataSO.BulletLifeTime);
        _isHoldLazer = false;
    }

    public bool IsHoldLazer()
    {
        return _isHoldLazer;
    }
}
