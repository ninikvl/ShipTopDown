using System.Collections;
using UnityEngine;

[RequireComponent (typeof(PlayerInput))]
[RequireComponent (typeof(Health))]
public class PlayerShip : SingletonMonoBehaviour<PlayerShip>
{
    private readonly float _xShipOffest = 0.5f;
    private readonly float _yShipOffest = 0.7f;
    private readonly float _spriteFlashInterval = 0.2f;

    private Coroutine _invulnerabilityRoutine;

    private Health _health;
    [SerializeField] private PlayerDataSO _playerData;

    private SpriteRenderer _spriteRenderer;

    public PlayerInput PlayerInput { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        PlayerInput = GetComponent<PlayerInput>();
        _health = GetComponent<Health>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _health.SetStartHealth(_playerData.StartHealth);
    }

    private void FixedUpdate()
    {
        Vector2 moveAmount = _playerData.MoveSpeed * Time.deltaTime * PlayerInput.RawMovement;
        if (PlayerInput.IsSpeedUp)
        {
            moveAmount *= _playerData.SpeedUp;
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

    public void SetShipSprite(int healthPoint)
    {
        if (healthPoint > 6)
            _spriteRenderer.sprite = _playerData.FullHealtSprite;
        else if (healthPoint <= 6 && healthPoint > 4)
            _spriteRenderer.sprite = _playerData.SlightDamageSprite;
        else if (healthPoint <= 4 && healthPoint > 2)
            _spriteRenderer.sprite = _playerData.DamagedSprite;
        else if (healthPoint <= 2)
            _spriteRenderer.sprite = _playerData.VeryDamagedSprite;
    }

    public void StartInvulnerability()
    {
        if (_invulnerabilityRoutine == null)
        {
            StartCoroutine(StartInvulnerabilityRoutine());
        }
    }

    private IEnumerator StartInvulnerabilityRoutine()
    {
        int iterations = Mathf.RoundToInt(_playerData.InvulnerabilityTime / _spriteFlashInterval / 2f);
        WaitForSeconds WaitForSecondsSpriteFlashInterval = new WaitForSeconds(_spriteFlashInterval);

        GetComponent<Collider2D>().enabled = false;

        while (iterations > 0)
        {
            _spriteRenderer.color = Color.red;

            yield return WaitForSecondsSpriteFlashInterval;

            _spriteRenderer.color = Color.white;

            yield return WaitForSecondsSpriteFlashInterval;

            iterations--;

            yield return null;

        }

        GetComponent<Collider2D>().enabled = true;
    }

    public Vector2 GetPlayerPositon()
    {
        return transform.position;
    }

    public void StartPlayerDestroy()
    {
        gameObject.SetActive(false);
    }
}
