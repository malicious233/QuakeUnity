using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Agitated : State
{
    EnemyEvents events;
    //NavMeshAgent agent;
    EnemyPathfinder pathfinder;
    EnemyCombat combat;

    [Header("STATE TRANSITIONS:")]
    [SerializeField] State Goto_TargetGone;

    

    public override void Awake()
    {
        base.Awake();
        events = GetComponent<EnemyEvents>();
        combat = GetComponent<EnemyCombat>();
        pathfinder = GetComponent<EnemyPathfinder>();


    }


    public void FixedUpdate()
    {
        Vector3 targetPos = AI.target.position;
        //agent.SetDestination(targetPos);
        pathfinder.SetDestination = targetPos;
        //Improve attack detection here

        float targetDist = Vector3.Distance(transform.position, targetPos);
        if (targetDist < combat.attackRange)
        {
            events.WillAttack?.Invoke(targetPos);
        }
        
        
    }
}
