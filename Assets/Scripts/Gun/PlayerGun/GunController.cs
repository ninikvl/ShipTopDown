using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GunDataSO _autoCannonGunData;
    [SerializeField] private GunDataSO _bigSpaceGunData;

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
            new BigSpaceGun (Gun.TierLevel.First, _bigSpaceGunData),
            new AutoCannon (Gun.TierLevel.First, _autoCannonGunData),
            new AutoCannon (Gun.TierLevel.First, _autoCannonGunData),
            new AutoCannon (Gun.TierLevel.First, _autoCannonGunData)
        };
    }

    private void Start()
    {
        _playerInput = PlayerShip.Instance.PlayerInput;

        _activeGun = _gunsList[0];
    }

    public void ChangeActiveWeapon(bool isNextWeapon)
    {
        int activeWeaponIndex;

        if (isNextWeapon)
        {
            activeWeaponIndex = _gunsList.IndexOf(_activeGun);
            if (activeWeaponIndex < _gunsList.Count - 1)
                _activeGun = _gunsList[++activeWeaponIndex];
            else
                _activeGun = _gunsList[0];
        }
        else
        {
            activeWeaponIndex = _gunsList.IndexOf(_activeGun);
            if (activeWeaponIndex > 0)
                _activeGun = _gunsList[--activeWeaponIndex];
            else
                _activeGun = _gunsList[_gunsList.Count - 1];
        }

        _animator.runtimeAnimatorController = _activeGun.GunDataSO.WeaponAnimatorController;
    }

    private void FixedUpdate()
    {
        if (_activeGun == null)
            Debug.LogException(new Exception("Активное оружие не установленно"));

        if (_playerInput.IsShoot && _shootCoroutine == null)
        {
            //_animator.speed = _activeGun.GetBulletSpawnInterval() / _activeGun.GetBulletSpawnInterval();
            _animator.CrossFade(Settings.PlayerGunShoot, 0, 0);
            _shootCoroutine = StartCoroutine(ShootRoutine());
        }
    }


    private IEnumerator ShootRoutine()
    {
        _activeGun.InitializeShoot(transform);

        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        _animator.CrossFade(Settings.PlayerGunIdle, 0, 0);

        yield return new WaitForSeconds(_activeGun.GetBulletSpawnInterval());
        _shootCoroutine = null;
    }

    public void GunTierUp()
    {
        _activeGun.UpTierLevel();
    }
}
