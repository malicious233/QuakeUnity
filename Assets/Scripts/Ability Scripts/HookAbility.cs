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
    [SerializeField] float swingBoost;
    [SerializeField] float hookRange;
    [SerializeField] float velocityReduction = 0.7f;
    [SerializeField] float hookJumpForce = 0.5f;
    [SerializeField] [Range(0,1)] float turnUntilBreak = 0.4f;
    [SerializeField] LayerMask grappleableMask;

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
                movement.velocity.y = hookJumpForce;
                isGrappling = true;
                grappleHitTransform.position = hit.point;
                grappleHitTransform.parent = hit.transform;
                rope.SetRope(grappleHitTransform);
            }
            
        }
    }

    private void StopGrapple()
        ///Stops the grapple
    {
        isGrappling = false;
        grappleHitTransform.position = Vector3.zero;
        rope.UnsetRope();
    }

    private void CancelGrappleJump()
        ///Cancels grapple with a jump
    {
        movement.velocity.y += hookJumpForce;
        StopGrapple();
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

        

        if (isGrappling)
        {

            Vector3 grappleVector = grappleHitTransform.position - transform.position;
            grappleVector.Normalize();

            float grapplePullForceMod = Vector3.Dot(grappleVector, transform.forward);
            Debug.Log(grapplePullForceMod);

            Vector3 grappleSwingBoostExtra = transform.forward * grapplePullForceMod * swingBoost;

            Vector3 grapplePullForce = grappleVector * pullStrength;

            movement.velocity += grapplePullForce * Time.deltaTime;
            movement.velocity += grappleSwingBoostExtra * Time.deltaTime;

            if (grapplePullForceMod < turnUntilBreak)
            {
                StopGrapple();
            }

            if (input.jumpDown)
            {
                CancelGrappleJump();
            }

            if (input.crouchHold)
            {
                StopGrapple();
            }

        }
    }

}
