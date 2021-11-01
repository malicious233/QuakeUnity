using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageable
{
    CharacterParticles particles;
    EnemyEvents events;

    public enum Team
    {
        player,
        enemy,
    }
    public Team team = new Team();

    public float maxHealth;
    public float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health -= value;
            health = Mathf.Clamp(health, 0, maxHealth);
        }

    }

    public void Awake()
    {
        particles = GetComponent<CharacterParticles>();
        events = GetComponent<EnemyEvents>();

        health = maxHealth;
    }

    //public event Action OnHit;

    public void InflictDamage(Damage _damage)
    {/*
        health -= _damage.damageValue;
        particles.EmitHitEffect();
        events.OnHit?.Invoke();
        if (health <= 0)
        {
            Die();
        }
        */
    }

    public void CauseHitEffects(float _damageMultiplier)
    {
        particles.EmitHitEffect();
        events.OnHit?.Invoke();
        if (_damageMultiplier != 1)
        {
            events.OnCrit?.Invoke(_damageMultiplier);
            particles.CritParticle(_damageMultiplier);
        }
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        particles.DeathParticle();
        Destroy(gameObject);
    }
}