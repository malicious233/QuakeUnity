using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAbility : MonoBehaviour, IAbility
{
    public Transform camTransform;
    IMoveable Imoveable;

    [Header("ATTRIBUTES:")]
    [SerializeField] float cooldown;
    [SerializeField] float pullStrength;
    [SerializeField] float hookRange;
    [SerializeField] LayerMask grappleableMask;

    
    public void DoAbility()
    {
        Vector3 grapplePoint;
        RaycastHit hit;

        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, hookRange, grappleableMask))
        {
            
        }
    }

    private void Awake()
    {
        Imoveable = GetComponentInParent<IMoveable>();
    }

}
