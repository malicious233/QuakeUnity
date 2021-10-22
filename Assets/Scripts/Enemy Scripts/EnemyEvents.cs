using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyEvents : MonoBehaviour
{
    public event Action OnHit;

    public void Invoke_OnHit()
    {
        OnHit?.Invoke();
    }
}
