using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IDamageable
{
    private CharacterParticles particles;

    public enum Team
    {
        player,
        enemy,
    }
    public Team team = new Team();

    public event Action OnHit;

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


    public void InflictDamage(Damage _damage)
    {
        health -= _damage.damageValue;
        particles.EmitHitEffect();
        Debug.Log("DAMAGE");
        if (health <= 0)
        {
            Debug.Log("Owowowow I am dead! Play death sequence");
        }
    }

}
