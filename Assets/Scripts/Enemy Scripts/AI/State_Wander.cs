using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Wander : State
{
    NavMeshAgent agent;


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
    [SerializeField] LayerMask layerMask;

    [Header("Movement Speeds:")]
    [SerializeField] float wanderSpeed = 1f;
    [SerializeField] float acceleration = 1f;
    

    public Vector3 moveDirection;

    public override void Awake()
    {
        base.Awake();
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

        if (timeTillDetect < 0)
        {
            timeTillDetect = detectRefreshRate;
            DetectEnemiesInRange();
        }
        timeTillDetect -= Time.deltaTime;

    }

    public override void SetState()
    {
        base.SetState();
        currWanderTime = wanderTime;
        agent.SetDestination(RandomNavMeshLocation());

    }


    private void DetectEnemiesInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, enemyDetectRange, layerMask);
        foreach (Collider col in cols)
        {
            AI.target = col.transform;
            ChangeState(Goto_EnemyDetected);
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

