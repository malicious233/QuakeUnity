using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Aiming : State
{
    EnemyEvents events;
    Ray aimRay;

    [Header("Aim Stats:")]
    [SerializeField] float aimDistance = 10f;
    [SerializeField] float fireCooldown = 1f;
    public float curFireCooldown;

    public override void Awake()
    {
        base.Awake();
        events = GetComponent<EnemyEvents>();
    }

    public void FixedUpdate()
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
        }
        curFireCooldown -= Time.deltaTime;


        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(aimRay.origin, aimRay.direction * aimDistance);
    }
}
