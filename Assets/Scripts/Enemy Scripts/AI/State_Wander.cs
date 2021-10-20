using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Wander : State
{
    [Header("State Transition:")]
    [SerializeField] State Goto_AfterWander;

    [Header("State Properties:")]
    [SerializeField] float wanderTime = 1;
    float currWanderTime;
    public override void StateLoop()
    {
        base.StateLoop();
        if (currWanderTime < 0)
        {
            currWanderTime = wanderTime;
            ChangeState(Goto_AfterWander);
        }
        currWanderTime -= Time.deltaTime;
    }
}
