using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public abstract class State : MonoBehaviour
{
    protected EnemyAI AI;


    public virtual void Awake()
    {
        AI = GetComponent<EnemyAI>();
    }





}
