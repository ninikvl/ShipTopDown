using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletDataSO_", menuName = "Scriptavle Objects/Bullet Info")]
public class BulletDataSO : ScriptableObject
{
    #region Header
    [Header("Параметры снаряда")]
    #endregion
    [SerializeField] public GameObject BulletPrefab;

    #region Header
    [Header("Урон снаряда")]
    #endregion
    [SerializeField] public int BulletDamageTier1;
    [SerializeField] public int BulletDamageTier2;
    [SerializeField] public int BulletDamageTier3;

    #region Header
    [Header("Скорость снаряда")]
    #endregion
    [SerializeField] public int BulletSpeedTier1;
    [SerializeField] public int BulletSpeedTier2;
    [SerializeField] public int BulletSpeedTier3;

    #region Header
    [Header("Продолжительность жизни снаряда")]
    #endregion
    [SerializeField] public float BulletLifeTime;
}
