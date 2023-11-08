using UnityEngine;

[CreateAssetMenu(fileName = "GunDataSO_", menuName = "Scriptavle Objects/Gun Info")]
public class GunDataSO : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public GameObject BulletPrefab;
    [SerializeField] public int BulletSpeed;
    [SerializeField] public float BulletSpawnInterval;
}
