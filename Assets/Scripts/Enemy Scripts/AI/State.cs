using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public abstract class State : MonoBehaviour
{
    EnemyAI AI;

    public void Awake()
    {
        AI = GetComponent<EnemyAI>();
    }

    public void ChangeState(State _state)
    {
        AI.currentState = _state;
    }

    public virtual void StateLoop()
        //Method which will loop in Update inside EnemyAI once it is said state
    {

    }
}
