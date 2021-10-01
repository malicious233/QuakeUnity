using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHitscan : GunFire
{
    public LayerMask layerMask;
    private GunParticles particles;

    [SerializeField] GunDamage shotDamage;

    public float range;

    public override void Shoot()
    {
        base.Shoot();
        RaycastHit hit = GetHitPoint();

        particles.muzzleFlash.Emit(1);

        Vector3 tracerPoint;

        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, range, layerMask))
        {
            var bulletHit = Instantiate(Instantiate(particles.bulletHitEffect, hit.point, Quaternion.identity));
            bulletHit.transform.forward = hit.normal;
            tracerPoint = hit.point;
            
        }
        else
        {
            tracerPoint = camTransform.forward * range;
        }

        particles.CreateTracer(tracerPoint);


    }
    public RaycastHit GetHitPoint()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, layerMask))
        {
            CharacterStats _stats = hit.transform.GetComponent<CharacterStats>();
            if (_stats != null)
            {
                _stats.InflictDamage(shotDamage.damageValue);
            }
            return hit;
        }
        return hit;
        
    }

    public override void Awake()
    {
        base.Awake();
        particles = GetComponent<GunParticles>();
    }


}
