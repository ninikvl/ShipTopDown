using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnought : EnemyAI
{
    private float yAnchorPosition = 10f;

    private EnemyGun EnemyGun;
    bool sdafasdffsda = true;


    private void FixedUpdate()
    {
        float offset = PlayerShip.Instance.GetPlayerPositon().x - transform.position.x;

        if (offset > 0.2f || offset < -0.2f)
            MoveToPosition(new Vector2(PlayerShip.Instance.GetPlayerPositon().x, transform.position.y), transform.position, 1f);

        if (sdafasdffsda)
        {
            EnemyGun.InitializeShoot();
            sdafasdffsda=false;
        }
    }


    private void Awake()
    {
        EnemyGun = GetComponent<EnemyGun>();
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


    public IEnumerator MoveToAnchorVerticalPosition()
    {
        while (transform.position.y > yAnchorPosition) 
        {
            transform.position = (Vector2)transform.position - new Vector2(0, 1) * Time.deltaTime * 1f;
            yield return new WaitForFixedUpdate();
        }
    }


    public override void MoveToPosition(Vector2 movePosition, Vector2 currentPosition, float moveSpeed)
    {
        base.MoveToPosition(movePosition, currentPosition, moveSpeed);
    }
}
