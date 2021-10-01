using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] ParticleSystem deathEffect;

    public void EmitHitEffect()
    {
        hitEffect.Emit(4);
    }

    public void DeathParticle()
    {

    }
}
