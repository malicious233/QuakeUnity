using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class S0ldierAnimator : MonoBehaviour
{
    [SerializeField] Transform aimTarget;
    [SerializeField] Animator anim;
    [SerializeField] Rig rig;
    NavMeshAgent agent;
    EnemyAI AI;

    
    

    private void Awake()
    {
        AI = GetComponent<EnemyAI>();
        agent = GetComponent<NavMeshAgent>();
        
    }


    private void Update()
    {
        UpdateAimTargetPosition();
        SetWalkingParameters();
    }

    private void UpdateAimTargetPosition()
        //Updates the aim target transform position which the rig constraint uses
    {
        if (AI.target == null)
        {
            SetRigWeights(false);
        }
        else
        {
            SetRigWeights(true);
            aimTarget.position = AI.PositionToAim();
            //aimTarget.position = aimTarget.TransformDirection(AI.target.position);
        }
        
    }

    private void SetWalkingParameters()
    {
        if (agent.velocity.magnitude > 0.01)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }

    private void SetRigWeights(bool _trueOrFalse)
    {
        if (_trueOrFalse)
        {
            rig.weight = 1;
        }
        else
        {
            rig.weight = 0;
        }
    }
}
