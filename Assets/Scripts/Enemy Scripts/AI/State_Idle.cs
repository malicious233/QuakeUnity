using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : State
{
    [Header("State Transition:")]
    [SerializeField] State Goto_AfterIdle;

    [Header("State Properties:")]
    [SerializeField] float idleTime = 1;
    float currIdleTime;
    /*
    public override void StateLoop()
    {
        base.StateLoop();
        if (currIdleTime < 0)
        {
            currIdleTime = idleTime;
            ChangeState(Goto_AfterIdle);
        }
        currIdleTime -= Time.deltaTime;
    }
    */

    public void Update()
    {
        if (currIdleTime < 0)
        {
            currIdleTime = idleTime;
            AI.ChangeState(Goto_AfterIdle);
        }
        currIdleTime -= Time.deltaTime;
    }
}
