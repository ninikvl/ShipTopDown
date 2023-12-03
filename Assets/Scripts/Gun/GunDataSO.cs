using UnityEngine;

[CreateAssetMenu(fileName = "GunDataSO_", menuName = "Scriptable Objects/Gun Info")]
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

    [SerializeField] public BulletDataSO BulletDataSO;
}
