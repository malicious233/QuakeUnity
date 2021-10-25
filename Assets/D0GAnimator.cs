using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class D0GAnimator : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;


    public void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
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

    
}
