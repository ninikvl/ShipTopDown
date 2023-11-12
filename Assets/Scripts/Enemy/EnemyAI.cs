using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    

    private void Update()
    {
    }


    private void FixedUpdate()
    {
    }


    public virtual void ActivateAI()
    {

    }


    public virtual void MoveToPosition(Vector2 movePosition, Vector2 currentPosition, float moveSpeed)
    {
        Vector3 unitVector = Vector3.Normalize(movePosition - currentPosition);

        transform.position = (Vector3)transform.position + (moveSpeed * Time.fixedDeltaTime * unitVector);
    }

}
