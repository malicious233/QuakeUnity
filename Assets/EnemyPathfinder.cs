using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinder : MonoBehaviour
{
    
    Vector3 destination;
    Vector3 moveVector;
    NavMeshPath path;
    
    [SerializeField] float pathRefreshRate;

    Vector3 SetDestination
    {
        set
        {
            destination = value;
        }
    }

    Vector3 MoveVector
    {
        get
        {
            return moveVector;
        }
    }

    Coroutine refreshPathRoutine;
    IEnumerator RefreshPathCoroutine()
    {
        while (1==1)
        {
            yield return new WaitForSeconds(pathRefreshRate);
            if (NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path))
            {
                Debug.Log("Vineboom");
                moveVector = path.corners[1] - transform.position;
                moveVector.Normalize();
            }
        }
        
    }

    private void Awake()
    {
        path = new NavMeshPath();
    }
    private void Start()
    {
        refreshPathRoutine = StartCoroutine(RefreshPathCoroutine());
        
    }

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, moveVector * 5);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}
