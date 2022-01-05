using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableEvents;

public class EnemyStats : MonoBehaviour, IDamageable
{
    [SerializeField] ScriptableEventFloat onHitlagEvent;

    [Header("VARIABLE REFERENCES:")]
    [SerializeField] FloatRef headshotHitlagRef;
    [SerializeField] FloatRef killHitlagRef;

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
        void PostHitlag()
        {
            events.OnCrit?.Invoke(_damageMultiplier);
            particles.CritParticle(_damageMultiplier);
        }

        particles.EmitHitEffect();
        events.OnHit?.Invoke();
        if (health <= 0)
        {
            onHitlagEvent.Raise(killHitlagRef.Value);
            StartCoroutine(WaitForHitlagEnd(Die));
        }
        if (_damageMultiplier != 1)
        {
            onHitlagEvent.Raise(headshotHitlagRef.Value);
            StartCoroutine(WaitForHitlagEnd(PostHitlag));

        }
        
        
    }


    public delegate void PostHitlag();

    IEnumerator WaitForHitlagEnd(PostHitlag _method)
    {
        while (Time.timeScale != 1.0f)
            yield return null;
        _method();
    }

    private void Die()
    {

        particles.DeathParticle();
        Destroy(gameObject);
    }
}