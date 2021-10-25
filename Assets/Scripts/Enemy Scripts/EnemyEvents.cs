using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyEvents : MonoBehaviour
{
    public Action OnHit;
    public Action<Vector3> WillAttack;
    public Action OnAttack;


}
