using UnityEngine;

[CreateAssetMenu(fileName = "GunDataSO_", menuName = "Scriptavle Objects/Gun Info")]
public class GunDataSO : ScriptableObject
{
    #region Header
    [Header("Параметры оружия")]
    #endregion
    [SerializeField] public string Name;
    [SerializeField] public string Description;
    [SerializeField] public Sprite GunSprite;


    #region Header
    [Header("Параметры снаряда")]
    #endregion
    [SerializeField] public GameObject BulletPrefab;
    [SerializeField] public int BulletSpeed;
    [SerializeField] public float BulletSpawnInterval;
    [SerializeField] public int BulletDamage;
    
}
