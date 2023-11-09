using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings 
{
    #region AnimationSettings
    public static int EnemyMoving = Animator.StringToHash("Moving");
    public static int EnemyShooting = Animator.StringToHash("Shooting");
    public static int EnemyDestruction = Animator.StringToHash("Destruction");
    #endregion
}
