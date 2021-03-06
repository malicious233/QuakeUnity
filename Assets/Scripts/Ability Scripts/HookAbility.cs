using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAbility : MonoBehaviour, IAbility
{
    public Transform camTransform;
    InputManager input;
    HookRopeRenderer rope;

    [SerializeField] Vector3Var playerVelocityVar;
    public Vector3 Velocity
    {
        get
        {
            return playerVelocityVar.Value;
        }
        set
        {
            playerVelocityVar.Value = value;
        }
    }

    [Header("ATTRIBUTES:")]
    [SerializeField] float cooldown;
    [SerializeField] float pullStrength;
    [SerializeField] float swingBoost;
    [SerializeField] float hookRange;
    [SerializeField] float velocityReduction = 0.7f;
    [SerializeField] float hookJumpForce = 0.5f;
    [SerializeField] [Range(0,1)] float turnUntilBreak = 0.4f;
    [SerializeField] LayerMask grappleableMask;
    [SerializeField] float hookSpeed = 3f;

    enum GrappleState
    {
        Neutral, //Nothing
        Moving, //Hook is moving
        Pulling //Pulling player
    }
    GrappleState grappleState = GrappleState.Neutral;

    
    [SerializeField] Transform hookTransform;
    [SerializeField] Transform hookSpotTransform;

    public Action grappleHit;

    public void UnholsterAbility()
    {

    }

    public void HolsterAbility()
    {

    }
    public void FireGrapple()
    {
        //Debug.Log("GrappleHit");
        RaycastHit hit;

        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, hookRange, grappleableMask))
        {
            if (hit.point != null && hit.transform != null)
            {


                

                grappleState = GrappleState.Moving;

                hookTransform.parent = null;

                hookSpotTransform.position = hit.point;
                hookSpotTransform.parent = hit.transform;
                hookTransform.position = transform.position;
                /*
                isGrappling = true;
                grappleHitTransform.position = hit.point;
                grappleHitTransform.parent = hit.transform;
                rope.SetRope(grappleHitTransform);
                */
                
                rope.SetRope(hookTransform);

            }
            
        }
    }

    private void StopGrapple()
        ///Stops the grapple
    {
        grappleState = GrappleState.Neutral;
        hookTransform.position = Vector3.zero;
        rope.UnsetRope();
    }

    private void CancelGrappleJump()
        ///Cancels grapple with a jump
    {
        Velocity += new Vector3(0, hookJumpForce, 0);
        StopGrapple();
    }

    private void GrappleHit()
    {
        grappleState = GrappleState.Pulling;
        Velocity = playerVelocityVar.Value * velocityReduction;
        Velocity += new Vector3(0, hookJumpForce, 0);
        grappleHit.Invoke();
    }

    

    private void Awake()
    {
        rope = GetComponent<HookRopeRenderer>();

        input = GetComponentInParent<InputManager>();
        
    }



    private void Update()
    {
        if (input.ability1Down)
        {
            FireGrapple();
            
        }

        if (grappleState == GrappleState.Moving)
        {
            hookTransform.position = Vector3.MoveTowards(hookTransform.position, hookSpotTransform.position, Time.deltaTime * hookSpeed);

            if (hookTransform.position == hookSpotTransform.position)
            {
                GrappleHit();
            }
        }
        else if (grappleState == GrappleState.Pulling)
        {
            Vector3 grappleVector = hookTransform.position - transform.position;
            grappleVector.Normalize();

            float grapplePullForceMod = Vector3.Dot(grappleVector, transform.forward);

            Vector3 grappleSwingBoostExtra = transform.forward * grapplePullForceMod * swingBoost;

            Vector3 grapplePullForce = grappleVector * pullStrength;

            Velocity += grapplePullForce * Time.deltaTime;
            Velocity += grappleSwingBoostExtra * Time.deltaTime;

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

        return;

        /*
        if (isGrappling)
        {

            Vector3 grappleVector = hookTransform.position - transform.position;
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
        */

        
    }

}
