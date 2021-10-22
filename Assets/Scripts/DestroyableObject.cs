using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth;
    private float health = 50;

    public event Action<Damage> OnHit;

    private void Awake()
    {
        health = maxHealth;
    }
    
    public void InflictDamage(Damage _damage)
    {
        health -= _damage.damageValue;
        OnHit?.Invoke(_damage);
        if (health <= 0)
        {
            DestroyObject();
        }
    }
    
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
