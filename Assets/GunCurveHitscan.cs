using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBezier;

public class GunCurveHitscan : GunFire
{
    LineRenderer line;
    Material mat;

    [SerializeField] GunDamage shotDamage;

    [Header("CURVE PROPERTIES:")]
    [SerializeField] Transform gunCurveAnchor;
    [SerializeField] Transform forwardCurveAnchor;
    [SerializeField] Transform magnetCurveAnchor;
    [SerializeField] int curveGranularity = 30;

    [Header("MATERIAL PROPERTIES:")]
    [SerializeField] Material curveHitMat;
    [SerializeField] Material curveNoHitMat;

    Vector3[] pointerLinePositions;

    public override void Awake()
    {
        base.Awake();
        line = GetComponent<LineRenderer>();

    }

    private void Update()
    {
        float distBetweenGunAndMagnet = (gunCurveAnchor.position - magnetCurveAnchor.position).magnitude;
        Vector3 curveAnchorOffset = new Vector3(0, 0, distBetweenGunAndMagnet/2);
        forwardCurveAnchor.localPosition = curveAnchorOffset;

        pointerLinePositions = new Vector3[curveGranularity];

        Vector3 prev = gunCurveAnchor.position;
        for (int i = 0; i < curveGranularity; i++)
        {
            float v = i / (curveGranularity - 1f);
            Vector3 p = Bezier.CalculateQuadraticBezierPoint(v, gunCurveAnchor.position, forwardCurveAnchor.position, magnetCurveAnchor.position);

            //Gizmos.DrawLine(prev, p);
            pointerLinePositions[i] = p;
            prev = p;

        }
        line.positionCount = curveGranularity;
        line.SetPositions(pointerLinePositions);

        RaycastHit hit;
        if (Bezier.CurveRaycast(gunCurveAnchor.position, forwardCurveAnchor.position, magnetCurveAnchor.position, curveGranularity, StaticVariables.hurtboxMask, out hit))
        {
            line.material = curveHitMat;
        }
        else
        {
            line.material = curveNoHitMat;
        }


    }

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
        if (Bezier.CurveRaycast(gunCurveAnchor.position, forwardCurveAnchor.position, magnetCurveAnchor.position, curveGranularity, hittableMask, out hit))
        {
            
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
