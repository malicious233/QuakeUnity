using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour
{
    private Transform targetTransform;

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


    private void State_Idle()
    {

    }
    

    private void State_Wander()
    {

    }

    private void State_Agitated()
    {

    }
}
