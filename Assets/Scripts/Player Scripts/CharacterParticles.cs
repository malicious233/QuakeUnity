using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] GameObject deathEffect;

    public void EmitHitEffect()
    {
        hitEffect.Emit(4);
    }

    public void DeathParticle()
    {
        Instantiate(deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
    }
}
