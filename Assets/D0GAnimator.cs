using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class D0GAnimator : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    EnemyEvents events;


    public void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        events = GetComponent<EnemyEvents>();
    }

    public void Update()
    {
        if (agent.velocity.sqrMagnitude > 0.05f)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
    }

    public void OnEnable()
    {
        events.OnAttack += Play_AttackAnim;
    }

    public void OnDisable()
    {
        events.OnAttack -= Play_AttackAnim;
    }

    private void Play_AttackAnim()
    {
        anim.Play("Attack", 0, 0);
    }


}
