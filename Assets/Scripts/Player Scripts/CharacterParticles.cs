using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] ParticleSystem critEffect;
    [SerializeField] GameObject deathEffect;

    public void EmitHitEffect()
    {
        hitEffect.Emit(4);
    }

    public void DeathParticle()
    {
        Instantiate(deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
    }

    public void CritParticle(float _damageMultiplier)
    {
        critEffect.Emit(((int)_damageMultiplier)*3);        
    }
}
