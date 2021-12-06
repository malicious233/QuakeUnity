using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HookParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem hookHitParticle;

    //HookAbility hook;

    public void PlayGrappleHit()
    {
        hookHitParticle.Play();
        //hookHitParticle.
        Debug.Log("Hi");
    }

    private void Awake()
    {
        HookAbility hook = GetComponent<HookAbility>();
        hook.grappleHit += PlayGrappleHit;
    }
}
