using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBezier;

public class GunCurveHitscan : GunFire
{
    [Header("CURVE PROPERTIES:")]
    [SerializeField] Transform gunCurveAnchor;
    [SerializeField] Transform forwardCurveAnchor;
    [SerializeField] Transform magnetCurveAnchor;
    [SerializeField] int curveGranularity = 30;

    [SerializeField] GameObject tst;

    [SerializeField] GunDamage shotDamage;

    public void OnDrawGizmos()
    {
        

        Vector3 prev = gunCurveAnchor.position;
        for (int i = 0; i < curveGranularity; i++)
        {
            float v = i / (curveGranularity - 1f);
            Vector3 p = Bezier.CalculateQuadraticBezierPoint(v, gunCurveAnchor.position, forwardCurveAnchor.position, magnetCurveAnchor.position);

            Gizmos.DrawLine(prev, p);
            prev = p;

        }
    }

    public override void Shoot()
    {
        base.Shoot();
        RaycastHit hit;
        if (Bezier.CurveRaycast(gunCurveAnchor.position, forwardCurveAnchor.position, magnetCurveAnchor.position, 30, hittableMask, out hit))
        {
            Debug.Log("SUCCESS");
            //Instantiate(tst, hit.point, Quaternion.identity);
            IDamageable _stats = hit.transform.GetComponent<IDamageable>();
            Damage damage = new Damage(shotDamage.damageValue, camTransform.forward);
            if (_stats != null)
            {
                _stats.InflictDamage(damage);
            }
        }
    }

    
}
