using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class D0GAnimator : MonoBehaviour
{
    Animator anim;
    EnemyEvents events;
    EnemyMovement movement;


    public void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        movement = GetComponent<EnemyMovement>();
        events = GetComponent<EnemyEvents>();
    }

    public void Update()
    {
        //Dumb!
        Vector3 noYVelocity = movement.Velocity;
        noYVelocity.y = 0;
        if (noYVelocity.sqrMagnitude > 0.05f)
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
