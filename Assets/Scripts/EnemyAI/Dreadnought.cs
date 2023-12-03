using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnought : EnemyAI
{
    [SerializeField] private float _yAnchorPosition = 14f;
     
    private DreadnoughtGun _dreadnoughtGun;
    
    
    protected override void Awake()
    {
        base.Awake();
        _dreadnoughtGun = GetComponent<DreadnoughtGun>();
        _isStopAI = false;
    }

    protected override void Update()
    {
        base.Update();

        if (IsShootPossible() && _dreadnoughtGun != null)
        {
            _enemy.StartEnemyAttack();
            _dreadnoughtGun.StartDreadnoughtShoot();
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (transform.position.y <= _yAnchorPosition)
        {
            float offset = PlayerShip.Instance.GetPlayerPositon().x - transform.position.x;

            if (offset > 0.2f || offset < -0.2f)
                MoveToPosition(new Vector2(PlayerShip.Instance.GetPlayerPositon().x, transform.position.y), transform.position, 1f);
        }
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
    }

    private bool IsShootPossible()
    {
        if (transform.position.y <= _yAnchorPosition && !_enemy.IsShooting && !_enemy.IsDestroying && !_dreadnoughtGun.IsHoldLazer()) 
            return true;
        else
            return false;
    }

    private IEnumerator MoveToAnchorVerticalPosition()
    {
        while (transform.position.y > _yAnchorPosition) 
        {
            transform.position = (Vector2)transform.position - 1f * Time.deltaTime * new Vector2(0, 1);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

    protected override void MoveToPosition(Vector2 movePosition, Vector2 currentPosition, float moveSpeed)
    {
        base.MoveToPosition(movePosition, currentPosition, moveSpeed);
    }
}
