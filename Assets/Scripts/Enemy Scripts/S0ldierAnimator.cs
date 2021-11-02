using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class S0ldierAnimator : MonoBehaviour
{
    [SerializeField] Transform aimTarget;
    [SerializeField] Animator anim;
    [SerializeField] Rig rig;
    EnemyAI AI;
    
    

    private void Awake()
    {
        AI = GetComponent<EnemyAI>();
        aimTarget.parent = null;
    }

    private void FixedUpdate()
    {
        UpdateAimTargetPosition();
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
            aimTarget.position = AI.target.position;
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
