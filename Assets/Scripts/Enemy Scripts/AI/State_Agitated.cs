using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Agitated : State
{
    EnemyEvents events;
    NavMeshAgent agent;

    [Header("State Transition:")]
    [SerializeField] State Goto_TargetGone;



    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        events = GetComponent<EnemyEvents>();
    }


    public void Update()
    {
        agent.SetDestination(AI.target.position);

        events.Invoke_OnAttack();
        
    }
}
