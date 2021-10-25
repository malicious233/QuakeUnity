using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    EnemyAI AI;
    EnemyEvents events;

    public float attackRange = 3;
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
    public void Attack(Vector3 _attackPos)
    {
        

        
        if (canAttack)
        {
            
            attackCooldownRoutine = StartCoroutine(AttackCooldownCoroutine());
            Collider[] cols = Physics.OverlapSphere(transform.position, attackRange, AI.enemyMask);
            if (cols.Length != 0)
            {
                events.OnAttack?.Invoke();

                //Inflict damage while creating DamageClass
                IDamageable d = cols[0].GetComponent<IDamageable>();
                Damage damage = new Damage(attackDamage, Vector3.zero);
                d.InflictDamage(damage);

                //Rotate towards enemy
                Vector3 vectorDirection = transform.position - _attackPos;
                vectorDirection.y = transform.position.y;
                transform.LookAt(_attackPos, Vector3.up);
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
        events.WillAttack += Attack;
    }

    public void OnDisable()
    {
        events.WillAttack -= Attack;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
