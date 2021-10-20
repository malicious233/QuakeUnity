using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    #region Unity Methods
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    #endregion

    #region Methods
    public void MoveToDestination(Vector3 _destination)
    {
        agent.SetDestination(_destination);
    }
    #endregion
}
