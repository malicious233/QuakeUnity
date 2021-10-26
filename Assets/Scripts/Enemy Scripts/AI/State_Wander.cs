using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Wander : State
{
    NavMeshAgent agent;
    EnemyEvents events;


    [Header("State Transition:")]
    [SerializeField] State Goto_AfterWander;
    [SerializeField] State Goto_EnemyDetected;

    [Header("State Properties:")]
    [SerializeField] float wanderTime = 1f;
    [SerializeField] float wanderRadius = 3f;
    float currWanderTime;
    [SerializeField] float detectRefreshRate = 0.2f;
    float timeTillDetect;
    [SerializeField] float enemyDetectRange = 3f;
    [SerializeField] float onHitAggroRange = 1000;

    [Header("Movement Speeds:")]
    [SerializeField] float wanderSpeed = 1f;
    [SerializeField] float acceleration = 1f;
    

    private Vector3 moveDirection;

    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        events = GetComponent<EnemyEvents>();
    }


    public void Update()
    {
        agent.Move(moveDirection * Time.deltaTime);
        if (currWanderTime < 0)
        {
            currWanderTime = wanderTime;
            AI.ChangeState(Goto_AfterWander);
        }
        currWanderTime -= Time.deltaTime;

        if (timeTillDetect < 0)
        {
            timeTillDetect = detectRefreshRate;
            DetectEnemiesInRange();
        }
        timeTillDetect -= Time.deltaTime;
    }


    public void OnEnable()
    {
        currWanderTime = wanderTime;
        agent.SetDestination(RandomNavMeshLocation());
        events.OnHit += AggroRange;
    }

    public void OnDisable()
    {
        events.OnHit -= AggroRange;
    }

    private void AggroRange()
    {
        AI.AggroAOE(onHitAggroRange, Goto_EnemyDetected);
    }





    private void DetectEnemiesInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, enemyDetectRange, AI.enemyMask);
        foreach (Collider col in cols)
        {
            AI.SetTarget(col.transform);
            //AI.target = col.transform;
            AI.ChangeState(Goto_EnemyDetected);
            Debug.Log("BWEEEOOEEEOO");
        }
        
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

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, enemyDetectRange);
    }
}

