using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO_", menuName = "Scriptavle Objects/Enemy Data")]
public class EnemyDataSO : ScriptableObject
{
    [SerializeField] public int HealthPoint;
    [SerializeField] public int MovementSpeed;
}
