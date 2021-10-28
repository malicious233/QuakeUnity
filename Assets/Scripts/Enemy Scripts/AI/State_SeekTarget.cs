using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_SeekTarget : State
{
    [Header("State Transitions:")]
    [SerializeField] State Goto_TargetFound;
    [SerializeField] float detectRange = 100f;

    NavMeshAgent agent;
    Ray aimRay;
    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    public void OnEnable()
    {
        
    }

    public void OnDisable()
    {
        //agent.SetDestination(transform.position);
    }

    public void Update()
    {
        agent.SetDestination(AI.target.position);
        Vector3 targetPos = AI.PositionToAim();

        Vector3 tr = transform.position;
        aimRay = new Ray(tr, targetPos - tr);
        RaycastHit hit;
        if (Physics.Raycast(aimRay.origin, aimRay.direction, out hit, detectRange, AI.enemyMask))
        {
            if (!Physics.Raycast(aimRay.origin, aimRay.direction, hit.distance, StaticVariables.groundMask))
            {
                AI.ChangeState(Goto_TargetFound);
            }
        }
        /*
        Vector3 vecDir = transform.position - AI.PositionToAim();
        vecDir.Normalize();
        if (!Physics.Raycast(transform.position, vecDir, detectRange, StaticVariables.groundMask))
        {
            AI.ChangeState(Goto_TargetFound);
        }
        */
    }
}