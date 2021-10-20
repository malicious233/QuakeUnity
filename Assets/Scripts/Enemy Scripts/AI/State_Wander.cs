using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyMovement))]
public class State_Wander : State
{
    EnemyMovement movement;
    NavMeshAgent agent;


    [Header("State Transition:")]
    [SerializeField] State Goto_AfterWander;

    [Header("State Properties:")]
    [SerializeField] float wanderTime = 1f;
    [SerializeField] float wanderRadius = 3f;
    float currWanderTime;

    [Header("Movement Speeds:")]
    [SerializeField] float wanderSpeed = 1f;
    [SerializeField] float acceleration = 1f;
    

    public Vector3 moveDirection;

    public override void Awake()
    {
        base.Awake();
        movement = GetComponent<EnemyMovement>();
        agent = GetComponent<NavMeshAgent>();
    }
    public override void StateLoop()
    {
        base.StateLoop();
        agent.Move(moveDirection * Time.deltaTime);
        if (currWanderTime < 0)
        {
            currWanderTime = wanderTime;
            ChangeState(Goto_AfterWander);
        }
        currWanderTime -= Time.deltaTime;

        NavMeshPathStatus status = agent.pathStatus;
        if (status == NavMeshPathStatus.PathComplete)
        {
            ChangeState(Goto_AfterWander);
        }
    }

    public override void SetState()
    {
        base.SetState();
        agent.SetDestination(RandomNavMeshLocation());
        /*
        agent.speed = wanderSpeed;
        agent.acceleration = acceleration;
        Vector2 dir = Random.insideUnitCircle.normalized;
        moveDirection.x = dir.x;
        moveDirection.z = dir.y;
        moveDirection.Normalize();
        */
        
        
        
        

        
    }

    private Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * wanderRadius;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, wanderRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}

