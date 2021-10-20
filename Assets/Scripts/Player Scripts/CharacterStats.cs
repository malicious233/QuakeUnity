using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
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

    public void InflictDamage(float damageValue)
    {
        health -= damageValue;
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
