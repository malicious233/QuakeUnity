using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyableObject))]
[RequireComponent(typeof(Rigidbody))]
public class PushableObject : MonoBehaviour
{
    Rigidbody rb;
    DestroyableObject destroyableObject;

    [SerializeField] float knockbackMultiplier = 1;
    
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        destroyableObject = GetComponent<DestroyableObject>();
    }

    public void OnEnable()
    {
        destroyableObject.OnHit += ApplyKnockback;
    }

    

    private void ApplyKnockback(Damage _damage)
    {
        rb.AddForce(_damage.knockbackDir * _damage.damageValue * knockbackMultiplier, ForceMode.Impulse);
    }
}
