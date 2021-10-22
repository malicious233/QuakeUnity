using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    EnemyAI AI;
    EnemyEvents events;

    [SerializeField] float attackRange = 3;
    [SerializeField] float attackDamage = 3;
    [SerializeField] float attackCooldown = 1;
    bool canAttack = true;

    IEnumerator AttackCooldownCoroutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    Coroutine attackCooldownRoutine;
    public void Attack()
    {
        

        
        if (canAttack)
        {
            Debug.Log("Swing!");
            attackCooldownRoutine = StartCoroutine(AttackCooldownCoroutine());
            Collider[] cols = Physics.OverlapSphere(transform.position, attackRange, AI.enemyMask);
            if (cols.Length != 0)
            {
                IDamageable d = cols[0].GetComponent<IDamageable>();
                Damage damage = new Damage(attackDamage, Vector3.zero);
                d.InflictDamage(damage);
            }
        }
        
    }

    

    public void Awake()
    {
        AI = GetComponent<EnemyAI>();
        events = GetComponent<EnemyEvents>();
    }

    public void OnEnable()
    {
        events.OnAttack += Attack;
    }

    public void OnDisable()
    {
        events.OnAttack -= Attack;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
