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

    private Coroutine _coroutine = null;

    private void Awake()
    {
        _gunsList = new List<Gun>()
        {
            new DefaultGun (Gun.TierLevel.First, _defaultGunData)
        };

        _activeGun = _gunsList[0];
    }

    private void Start()
    {
        _playerInput = PlayerShip.Instance.PlayerInput;
    }

    private void FixedUpdate()
    {
        if (_activeGun == null)
            Debug.LogException(new Exception("Активное оружие не установленно"));

        if (_playerInput.IsShoot && _coroutine == null)
        {
            _coroutine = StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        _activeGun.InitializeShoot(transform.position);

        yield return new WaitForSeconds(_activeGun.GunDataSO.BulletSpawnInterval);
        _coroutine = null;
    }
}
