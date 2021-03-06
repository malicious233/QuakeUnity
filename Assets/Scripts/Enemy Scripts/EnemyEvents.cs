using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyEvents : MonoBehaviour
{
    public Action OnHit; //Is invoked when this enemy is hit
    public Action OnAttack; //Is invoked when an attack is performed

    public Action<float> OnCrit; //If damage multiplier is not 1

    public Action<Vector3> Shoot; //Is invoked when you want to shoot at a position
    public Action<Vector3> OnUpdateMoveVector; //Is invoked to update EnemyPathfinders inputvector for enemymovement to use
    public Action<Vector3> WillAttack; //Is invoked when the enemy can attack at next possible moment

    public Action<Transform> OnUpdateTarget; //Is invoked to update current target to chase


}
