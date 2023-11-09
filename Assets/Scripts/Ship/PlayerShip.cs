using UnityEngine;

public class PlayerShip : SingletonMonoBehaviour<PlayerShip>
{
    private readonly float _moveSpeed = 3f;
    private readonly float _speedUp = 3f;

    private readonly float _xLeftBorder = -5.5f;
    private readonly float _xRightBorder = 23.3f;
    private readonly float _yUpBorder = 12.58f;
    private readonly float _yDownBorder = -2.2f;

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
        if (transform.position.x < _xLeftBorder)
        {
            transform.position = new Vector2(_xLeftBorder, transform.position.y);
        }
        else if (transform.position.x > _xRightBorder)
        {
            transform.position = new Vector2(_xRightBorder, transform.position.y);
        }

        if (transform.position.y > _yUpBorder)
        {
            transform.position = new Vector2(transform.position.x, _yUpBorder);
        }
        else if (transform.position.y < _yDownBorder)
        {
            transform.position = new Vector2(transform.position.x, _yDownBorder);
        }
    }


    public void PlayerDestroyed()
    {

    }
}
