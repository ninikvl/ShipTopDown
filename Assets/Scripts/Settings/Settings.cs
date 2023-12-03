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

    #region BulletAnimations
    public static int LazerAnimation = Animator.StringToHash("Lazer");
    public static int CommonBulletAnimation = Animator.StringToHash("CommonBulletAnimation");
    #endregion

    #region WeaponAnimation
    public static int AutoCannonShoot = Animator.StringToHash("AutoCannonShoot");
    #endregion

    #region MapCoorinates
    public static Vector2 LeftUpBoarder = new Vector2(0f, 16.875f);
    public static Vector2 RightDownBoarder = new Vector2(30f, 0f);
    #endregion



}
