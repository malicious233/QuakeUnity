using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Agitated : State
{
    NavMeshAgent agent;

    [Header("State Transition:")]
    [SerializeField] State Goto_TargetGone;

    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }
    /*
    public override void StateLoop()
    {
        base.StateLoop();
        agent.SetDestination(AI.target.position);
    }
    */

    public void Update()
    {
        agent.SetDestination(AI.target.position);
    }
}
