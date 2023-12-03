using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate : EnemyAI
{
    private float _followDistance;

    private FrigateGun _frigateGun;

    protected override void Awake()
    {
        base.Awake();

        _frigateGun = GetComponent<FrigateGun>();
    }

    private void Start()
    {
        ActivateAI();
    }

    protected override void Update()
    {
        base.Update();
        if(!_enemy.IsShooting)
            CheckAttack();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_isMovingToArena)
            return;

        FollowPlayer();
    }

    public override void ActivateAI()
    {
        base.ActivateAI();

        StartCoroutine(MoveToArena(_yShipOffset));
        StartCoroutine(ChangeFollowDistance());
    }

    public override void DeactivateAI()
    {
        base.DeactivateAI();

        _frigateGun.StopAllCoroutines();
    }

    private void CheckAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 15f, LayerMask.GetMask("Player"));

        if (hit.collider != null)
        {
            _enemy.StartEnemyAttack();
            _frigateGun.InitializeShoot();
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * 10f, Color.red);
    }

    private void FollowPlayer()
    {
        float xOffset = PlayerShip.Instance.GetPlayerPositon().x - transform.position.x;
        float yOffset = transform.position.y - PlayerShip.Instance.GetPlayerPositon().y;
        Vector2 movePosition;

        if (xOffset > 0.2f || xOffset < -0.2f)
        {
            movePosition = new Vector2(PlayerShip.Instance.GetPlayerPositon().x, transform.position.y);
            MoveToPosition(movePosition, transform.position, _enemy.EnemyDataSO.MovementSpeed);
        }

        if (yOffset < _followDistance - 0.2f || yOffset > _followDistance + 0.2f)
        {
            movePosition = new Vector2(transform.position.x, transform.position.y + _followDistance - yOffset);

            MoveToPosition(movePosition, transform.position, _enemy.EnemyDataSO.MovementSpeed);
        }

        CheckBoarder();
    }

    private IEnumerator ChangeFollowDistance()
    {
        while (true)
        {
            _followDistance = Random.Range(6f, 8f);
            yield return new WaitForSeconds(3f);
            _followDistance = Random.Range(10f, 14f);
            yield return new WaitForSeconds(3f);
        }
    }

    protected override void MoveToPosition(Vector2 movePosition, Vector2 currentPosition, float moveSpeed)
    {
        base.MoveToPosition(movePosition, currentPosition, moveSpeed);
    }

    protected override IEnumerator MoveToArena(float yOffset)
    {
        return base.MoveToArena(yOffset);
    }

    protected override void CheckBoarder()
    {
        base.CheckBoarder();
    }
}
