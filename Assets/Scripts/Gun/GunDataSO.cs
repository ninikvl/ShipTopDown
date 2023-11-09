using UnityEngine;

[CreateAssetMenu(fileName = "GunDataSO_", menuName = "Scriptavle Objects/Gun Info")]
public class GunDataSO : ScriptableObject
{
    #region Header Орудие
    [Header("Орудие")]
    #endregion
    #region Header
    [Header("Параметры орудия")]
    #endregion
    [SerializeField] public string Name;
    [SerializeField] public string Description;
    [SerializeField] public Sprite GunSprite;

    #region Header
    [Header("Скорострельность орудия")]
    #endregion
    [SerializeField] public float BulletSpawnIntervalTier1;
    [SerializeField] public float BulletSpawnIntervalTier2;
    [SerializeField] public float BulletSpawnIntervalTier3;


    #region Header Снаряд
    [Header("Снаряд")]
    #endregion
    #region Header
    [Header("Параметры снаряда")]
    #endregion
    [SerializeField] public GameObject BulletPrefab;
    [SerializeField] public int BulletSpeed;

    #region Header
    [Header("Урон снаряда")]
    #endregion
    [SerializeField] public int BulletDamageTier1;
    [SerializeField] public int BulletDamageTier2;
    [SerializeField] public int BulletDamageTier3;
}
