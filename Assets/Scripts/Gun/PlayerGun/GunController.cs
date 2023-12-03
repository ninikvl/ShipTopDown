using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GunDataSO _autoCannonGunData;

    private List<Gun> _gunsList;

    private Coroutine _shootCoroutine = null;

    private Gun _activeGun;
    private PlayerInput _playerInput;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        _gunsList = new List<Gun>()
        {
            new AutoCannon (Gun.TierLevel.First, _autoCannonGunData)
        };

        _activeGun = _gunsList[0];
        _spriteRenderer.sprite = _activeGun.GunDataSO.GunSprite;
    }


    private void Start()
    {
        _playerInput = PlayerShip.Instance.PlayerInput;
    }


    private void FixedUpdate()
    {
        if (_activeGun == null)
            Debug.LogException(new Exception("Активное оружие не установленно"));

        if (_playerInput.IsShoot && _shootCoroutine == null)
        {
            _animator.speed = _activeGun.GetBulletSpawnInterval() / _activeGun.GetBulletSpawnInterval();
            _animator.CrossFade(Settings.AutoCannonShoot, 0, 0);
            _shootCoroutine = StartCoroutine(ShootRoutine());
        }
    }


    private IEnumerator ShootRoutine()
    {
        _activeGun.InitializeShoot(transform);

        yield return new WaitForSeconds(_activeGun.GetBulletSpawnInterval());
        _shootCoroutine = null;
    }

    public void GunTierUp()
    {
        _activeGun.UpTierLevel();
    }
}
