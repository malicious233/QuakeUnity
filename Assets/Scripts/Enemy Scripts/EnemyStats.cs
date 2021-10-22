using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageable
{
    private CharacterParticles particles;
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

        health = maxHealth;
    }

    public event Action OnHit;

    public void InflictDamage(Damage _damage)
    {
        health -= _damage.damageValue;
        particles.EmitHitEffect();
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