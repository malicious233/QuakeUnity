using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : State
{
    [Header("State Transition:")]
    [SerializeField] State Goto_AfterIdle;
    [SerializeField] State Goto_AfterHit;
    

    [Header("State Properties:")]
    [SerializeField] float idleTime = 1;
    float currIdleTime;
    [SerializeField] float onHitAggroRange = 1000;

    EnemyEvents events;


    public override void Awake()
    {
        base.Awake();
        events = GetComponent<EnemyEvents>();

    }

    public void Update()
    {
        if (currIdleTime < 0)
        {
            currIdleTime = idleTime;
            AI.ChangeState(Goto_AfterIdle);
        }
        currIdleTime -= Time.deltaTime;
    }

    public void OnEnable()
    {
        events.OnHit += AggroRange;
    }

    public void OnDisable()
    {
        events.OnHit -= AggroRange;
    }

    private void AggroRange()
    {
        AI.AggroAOE(onHitAggroRange, Goto_AfterHit);
    }
}
