using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO_", menuName = "Scriptable Objects/Player Info")]
public class PlayerDataSO : ScriptableObject
{
    #region Header
    [Header("Скорость передвижения")]
    #endregion
    [SerializeField] public float MoveSpeed;
    [SerializeField] public float SpeedUp;

    #region Header
    [Header("Стартовое здоровье")]
    #endregion
    [SerializeField] public int StartHealth;

    #region Header
    [Header("Спрайты корабля")]
    #endregion
    [SerializeField] public Sprite FullHealtSprite;
    [SerializeField] public Sprite SlightDamageSprite;
    [SerializeField] public Sprite DamagedSprite;
    [SerializeField] public Sprite VeryDamagedSprite;

    #region Header
    [Header("Время неуязвимости после получения урона")]
    #endregion
    [SerializeField] public float InvulnerabilityTime;
}
