using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public State currentState;
    public void Update()
    {
        currentState.StateLoop();
    }
}
