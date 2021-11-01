using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class HurtboxScript : MonoBehaviour, IDamageable
{
    EnemyStats stats;

    [SerializeField] float damageMultiplier = 1;
    public void InflictDamage(Damage damageClass)
    {
        Debug.Log(damageClass.damageValue * damageMultiplier);
        stats.health -= damageClass.damageValue * damageMultiplier;
        stats.CauseHitEffects(damageMultiplier);
    }

    public void Awake()
    {
        stats = GetComponentInParent<EnemyStats>();
    }



}
