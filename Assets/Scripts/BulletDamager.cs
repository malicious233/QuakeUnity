using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damage))]
public class BulletDamager : MonoBehaviour
{
    SphereCollider col;

    Damage damageClass;
    [SerializeField] float damageValue = 5;
    [SerializeField] float hitboxRadius = 3;
    
    [SerializeField] LayerMask enemyMask;

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
        damageClass = new Damage(damageValue, Vector3.zero);

    }

    public void FixedUpdate()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, hitboxRadius, enemyMask);
        if (cols.Length != 0)
        {
            IDamageable dmgble = cols[0].GetComponent<IDamageable>();
            dmgble.InflictDamage(damageClass);
            Destroy(gameObject);
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, hitboxRadius);
    }
}
