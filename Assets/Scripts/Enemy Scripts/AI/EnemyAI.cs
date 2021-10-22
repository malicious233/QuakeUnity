using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public State currentState;
    public Transform target;

    public State[] states;

    public void Update()
    {
        //currentState.StateLoop();
    }

    public void Awake()
    {
        states = GetComponents<State>();
    }

    public void Start()
    {
        ChangeState(currentState);
    }

    public void ChangeState(State _state)
    {
        
        foreach (State state in states)
        {
            state.enabled = false;
        }
        currentState = _state;
        currentState.enabled = true;
    }
}
