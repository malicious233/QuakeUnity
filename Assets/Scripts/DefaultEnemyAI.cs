using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefaultEnemyAI : MonoBehaviour
{
    private Transform targetTransform;
    private NavMeshAgent agent;

    

    public enum State 
    {
        idle,
        wander,
        agitated,
    }
    public State state = State.idle;

    [Header("General AI properties")]
    [Tooltip("Rate at which AI updates states")]
    [SerializeField] private float aiUpdateRate = 0.1f;

    [Header("Idle State properties:")]
    [Tooltip("How long will AI idle before wandering again")]
    [SerializeField] private float idleTime = 0.5f;

    [Header("Wander State properties:")]
    [Tooltip("For how long will AI wander until going idle again")]
    [SerializeField] private float wanderTime = 0.5f;

    [Header("Agitated State properties:")]
    [SerializeField] private float chasePathUpdateRate = 0.1f;

    #region State Methods

    private void State_Idle()
    {

    }
    

    private void State_Wander()
    {

    }

    private void State_Agitated()
    {

    }

    #endregion

    #region Unity Methods
    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {

    }

    #endregion


}
