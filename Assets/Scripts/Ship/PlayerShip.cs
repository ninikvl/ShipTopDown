using UnityEngine;

public class PlayerShip : SingletonMonoBehaviour<PlayerShip>
{
    private readonly float _moveSpeed = 3f;
    private readonly float _speedUp = 3f;

    private readonly float _xShipOffest = 0.5f;
    private readonly float _yShipOffest = 0.7f;

    public PlayerInput PlayerInput { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        PlayerInput = GetComponent<PlayerInput>();
    }


    private void FixedUpdate()
    {
        Vector2 moveAmount = _moveSpeed * Time.deltaTime * PlayerInput.RawMovement;
        if (PlayerInput.IsSpeedUp)
        {
            moveAmount *= _speedUp;
        }

        transform.position = (Vector2)transform.position + moveAmount;
        CheckBorder();
    }


    private void CheckBorder()
    {
        if (transform.position.x < Settings.LeftUpBoarder.x + _xShipOffest)
        {
            transform.position = new Vector2(Settings.LeftUpBoarder.x + _xShipOffest, transform.position.y);
        }
        else if (transform.position.x > Settings.RightDownBoarder.x + _xShipOffest)
        {
            transform.position = new Vector2(Settings.RightDownBoarder.x + _xShipOffest, transform.position.y);
        }

        if (transform.position.y > Settings.LeftUpBoarder.y - _yShipOffest)
        {
            transform.position = new Vector2(transform.position.x, Settings.LeftUpBoarder.y - _yShipOffest);
        }
        else if (transform.position.y < Settings.RightDownBoarder.y + _yShipOffest)
        {
            transform.position = new Vector2(transform.position.x, Settings.RightDownBoarder.y + _yShipOffest);
        }
    }


    public Vector2 GetPlayerPositon()
    {
        return transform.position;
    }


    public void PlayerDestroyed()
    {

    }
}
