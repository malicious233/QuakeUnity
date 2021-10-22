using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyEvents : MonoBehaviour
{
    public event Action OnHit;
    public event Action OnAttack;

    public void Invoke_OnHit()
    {
        OnHit?.Invoke();
    }

    public void Invoke_OnAttack()
    {
        OnAttack?.Invoke();
    }
}
