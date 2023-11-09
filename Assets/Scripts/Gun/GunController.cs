using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GunDataSO _defaultGunData;

    private List<Gun> _gunsList;

    private Gun _activeGun;

    private PlayerInput _playerInput;

    private Coroutine _ShootCoroutine = null;

    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _gunsList = new List<Gun>()
        {
            new AutoCannon (Gun.TierLevel.First, _defaultGunData)
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

        if (_playerInput.IsShoot && _ShootCoroutine == null)
        {
            _ShootCoroutine = StartCoroutine(ShootRoutine());
        }
    }


    private IEnumerator ShootRoutine()
    {
        _activeGun.InitializeShoot(transform.position);

        yield return new WaitForSeconds(_activeGun.GetBulletSpawnInterval());
        _ShootCoroutine = null;
    }

    public void GunTierUp()
    {
        _activeGun.UpTierLevel();
    }
}
