using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public abstract class EnemyAI : MonoBehaviour
{
    protected Enemy _enemy;

    protected bool _isStopAI = true;
    protected bool _isMovingToArena = false;

    protected float _xShipOffset = 1f;
    protected float _yShipOffset = 1f;

    protected virtual void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _xShipOffset = _enemy.EnemyDataSO.xShipOffest;
        _yShipOffset = _enemy.EnemyDataSO.yShipOffest;
    }

    protected virtual void Update()
    {
        if (_isStopAI)
            return;
    }

    protected virtual void FixedUpdate()
    {
        if (_isStopAI)
            return;
    }

    public virtual void ActivateAI()
    {
        _isStopAI = false;
    }

    public virtual void DeactivateAI() 
    {
        _isStopAI = true;

        StopAllCoroutines();
    }

    protected virtual void MoveToPosition(Vector2 movePosition, Vector2 currentPosition, float moveSpeed)
    {
        Vector3 unitVector = Vector3.Normalize(movePosition - currentPosition);

        transform.position = (Vector3)transform.position + (moveSpeed * Time.fixedDeltaTime * unitVector);
    }

    protected virtual IEnumerator MoveToArena(float yOffset)
    {
        _isMovingToArena = true;

        while (transform.position.y > Settings.LeftUpBoarder.y - yOffset)
        {
            yield return new WaitForFixedUpdate();
            Vector2 downMoveVector = new(transform.position.x, transform.position.y - 1f);
            MoveToPosition(downMoveVector, transform.position, _enemy.EnemyDataSO.MovementSpeed);
        }

        _isMovingToArena = false;
        yield break;
    }

    protected virtual void CheckBoarder()
    {
        if (transform.position.x < Settings.LeftUpBoarder.x + _xShipOffset)
        {
            transform.position = new Vector2(Settings.LeftUpBoarder.x + _xShipOffset, transform.position.y);
        }
        else if (transform.position.x > Settings.RightDownBoarder.x + _xShipOffset)
        {
            transform.position = new Vector2(Settings.RightDownBoarder.x + _xShipOffset, transform.position.y);
        }

        if (transform.position.y > Settings.LeftUpBoarder.y - _yShipOffset)
        {
            transform.position = new Vector2(transform.position.x, Settings.LeftUpBoarder.y - _yShipOffset);
        }
        else if (transform.position.y < Settings.RightDownBoarder.y + _yShipOffset)
        {
            transform.position = new Vector2(transform.position.x, Settings.RightDownBoarder.y + _yShipOffset);
        }
    }
}
