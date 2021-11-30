using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAbility : MonoBehaviour, IAbility
{
    public Transform camTransform;
    PlayerController movement;
    InputManager input;
    HookRopeRenderer rope;

    [Header("ATTRIBUTES:")]
    [SerializeField] float cooldown;
    [SerializeField] float pullStrength;
    [SerializeField] float pullAccel;
    [SerializeField] float hookRange;
    [SerializeField] float velocityReduction = 0.7f;
    [SerializeField] LayerMask grappleableMask;
    float pullCurrAccel;

    bool isGrappling = false;
    
    [SerializeField] Transform grappleHitTransform;

    
    public void DoAbility()
    {
        Debug.Log("GrappleHit");
        RaycastHit hit;

        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, hookRange, grappleableMask))
        {
            if (hit.point != null && hit.transform != null)
            {
                movement.velocity = movement.velocity * velocityReduction;
                isGrappling = true;
                grappleHitTransform.position = hit.point;
                grappleHitTransform.parent = hit.transform;
                rope.SetRope(grappleHitTransform);
            }
            
        }
    }

    private void Awake()
    {
        rope = GetComponent<HookRopeRenderer>();

        input = GetComponentInParent<InputManager>();
        movement = GetComponentInParent<PlayerController>();
        
    }



    private void Update()
    {
        if (input.ability1Down)
        {
            DoAbility();
            
        }

        if (input.jumpDown)
        {
            isGrappling = false;
            grappleHitTransform.position = Vector3.zero;
            rope.UnsetRope();
            pullCurrAccel = 0;
        }

        if (isGrappling)
        {
            pullCurrAccel += pullAccel * Time.deltaTime;
            pullCurrAccel = Mathf.Clamp01(pullCurrAccel);

            Vector3 grapplePullDirection = grappleHitTransform.position - transform.position;
            grapplePullDirection.Normalize();
            Vector3 grapplePullForce = grapplePullDirection * pullCurrAccel * pullStrength * Time.deltaTime;

            movement.velocity += grapplePullForce;
            
        }
    }

}
