using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinder : MonoBehaviour
{
    EnemyEvents events;
    NavMeshPath path;

    Vector3 destination;
    Vector3 moveVector;


    [SerializeField] float pathRefreshRate;
    public Vector3 SetDestination
    {
        set
        {
            destination = value;
        }
    }
    


    public Vector3 MoveVector
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
            NavMeshHit pathHit;
            
            yield return new WaitForSeconds(pathRefreshRate);
            if (NavMesh.SamplePosition(destination, out pathHit, 8, NavMesh.AllAreas) && NavMesh.CalculatePath(transform.position, pathHit.position, NavMesh.AllAreas, path) && path.corners.Length >= 1)
            {
                Debug.Log("Vineboom");
                moveVector = path.corners[1] - transform.position;
                moveVector.Normalize();
                events.OnUpdateMoveVector?.Invoke(moveVector);
            }
            else
            {
                moveVector = Vector3.zero;
                events.OnUpdateMoveVector?.Invoke(moveVector);
            }
            
        }
        
    }

    private void UpdateDestination(Vector3 _destination)
    {
        SetDestination = _destination;
    }

    #region Unity Methods

    private void Awake()
    {
        events = GetComponent<EnemyEvents>();

        path = new NavMeshPath();
    }
    private void Start()
    {
        refreshPathRoutine = StartCoroutine(RefreshPathCoroutine());
        
    }

    private void OnEnable()
    {
        events.OnUpdateMoveVector += UpdateDestination;
    }

    private void OnDisable()
    {
        events.OnUpdateMoveVector -= UpdateDestination;
    }

    private void OnDrawGizmos()
    {
        //Ray ray = new Ray(transform.position, moveVector * 5);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + moveVector * 5);
        //Gizmos.DrawRay(ray);
    }

    #endregion
}
