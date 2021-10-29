using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Aiming : State
{
    EnemyEvents events;
    Ray aimRay;

    [Header("STATE TRANSITIONS:")]
    [Tooltip("After target gets obstructed or out of range")]
    [SerializeField] State Goto_EnemyGone;

    [Header("STATE PROPERTIES:")]
    [SerializeField] float aimDistance = 10f;
    [SerializeField] float fireCooldown = 1f;
    public float curFireCooldown;

    public override void Awake()
    {
        base.Awake();
        events = GetComponent<EnemyEvents>();
    }

    public void Update()
    {
        //Create aim Vector
        //Vector3 targetPos = AI.target.position;
        Vector3 targetPos = AI.PositionToAim();

        Vector3 tr = transform.position;
        aimRay = new Ray(tr, targetPos - tr);

        RaycastHit hit;
        if (curFireCooldown < 0 && Physics.Raycast(aimRay.origin, aimRay.direction, out hit, aimDistance, AI.enemyMask))
        {
            if (!Physics.Raycast(aimRay.origin, aimRay.direction, hit.distance, StaticVariables.groundMask))
            {
                //Add shoot logic here
                curFireCooldown = fireCooldown;
                events.Shoot.Invoke(aimRay.direction);
            }
            else
            {
                AI.ChangeState(Goto_EnemyGone);
            }
        }
        curFireCooldown -= Time.deltaTime;


        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(aimRay.origin, aimRay.direction * aimDistance);
    }
}
