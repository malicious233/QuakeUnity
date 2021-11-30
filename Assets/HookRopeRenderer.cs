using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRopeRenderer : MonoBehaviour
{
    LineRenderer line;
    Transform hookSpot;
    [SerializeField] Transform hookStartTransform;


    public void SetRope(Transform _hookSpot)
    {
        hookSpot = _hookSpot;
        
    }

    public void UnsetRope()
    {
        hookSpot = transform;
    }

    private void Awake()
    {

        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        line.positionCount = 2;
    }

    private void Update()
    {
        if (hookSpot != null)
        {
            /*
            lineSpots[0] = transform.position;
            lineSpots[1] = hookSpot.position;
            line.SetPositions(lineSpots);
            */
            line.SetPosition(0, hookStartTransform.position);
            line.SetPosition(1, hookSpot.position);
        }
        
    }
}
