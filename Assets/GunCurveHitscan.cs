using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBezier;

public class GunCurveHitscan : GunFire
{
    GunParticles particles;
    LineRenderer line;
    InputManager input;
    Material mat;

    [SerializeField] GunDamage shotDamage;

    [Header("CURVE PROPERTIES:")]
    [SerializeField] Transform gunCurveAnchor;
    [SerializeField] Transform forwardCurveAnchor;
    //[SerializeField] Transform magnetCurveAnchor;
    [SerializeField] MagnetTransformReference magnetTransformReference;
    [SerializeField] int curveGranularity = 30;

    [Header("VISUAL CURVE PROPERTIES:")]
    [SerializeField] Material curveHitMat;
    [SerializeField] Material curveNoHitMat;
    public bool lineVisible;

    Vector3[] pointerLinePositions;

    public override void Awake()
    {
        base.Awake();
        line = GetComponent<LineRenderer>();
        particles = GetComponent<GunParticles>();
        input = GetComponentInParent<InputManager>();//So ugly, please do better, Alfons.
        

    }

    private void Update()
    {
        Vector3 magnetAnchor_ = magnetTransformReference.magnetTransform.position;

        float distBetweenGunAndMagnet = (gunCurveAnchor.position - magnetAnchor_).magnitude;
        Vector3 curveAnchorOffset = new Vector3(0, 0, distBetweenGunAndMagnet/2);
        forwardCurveAnchor.localPosition = curveAnchorOffset;

        pointerLinePositions = new Vector3[curveGranularity];

        Vector3 prev = gunCurveAnchor.position;
        for (int i = 0; i < curveGranularity; i++)
        {
            float v = i / (curveGranularity - 1f);
            Vector3 p = Bezier.CalculateQuadraticBezierPoint(v, gunCurveAnchor.position, forwardCurveAnchor.position, magnetAnchor_);

            //Gizmos.DrawLine(prev, p);
            pointerLinePositions[i] = p;
            prev = p;

        }
        line.positionCount = curveGranularity;
        line.SetPositions(pointerLinePositions);
        //Cut it up so the line renderer is on a different component than the hitscan 

        RaycastHit hit;
        if (Bezier.CurveRaycast(gunCurveAnchor.position, forwardCurveAnchor.position, magnetAnchor_, curveGranularity, StaticVariables.hurtboxMask, out hit))
        {
            line.material = curveHitMat;
        }
        else
        {
            line.material = curveNoHitMat;
        }

        if (input.fireHold)
        {
            ToggleLine(true);
        }
        else
        {
            ToggleLine(false);
        }




    }

    /*
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
    */

    public override void Shoot()
    {
        base.Shoot();

        Vector3 magnetAnchor_ = magnetTransformReference.magnetTransform.position;

        RaycastHit hit;
        Vector3[] curvePositions;
        if (Bezier.CurveRaycast(gunCurveAnchor.position, forwardCurveAnchor.position, magnetAnchor_, curveGranularity, hittableMask, out hit, out curvePositions))
        {
            //Particles
            particles.CreateCurvedTracer(curvePositions);


            //Inflict damage
            IDamageable _stats = hit.transform.GetComponent<IDamageable>();
            Damage damage = new Damage(shotDamage.damageValue, camTransform.forward);
            if (_stats != null)
            {
                _stats.InflictDamage(damage);
            }
        }
    }

    public void ToggleLine(bool _trueOrFalse)
    {
        line.enabled = _trueOrFalse;
    }

    
}
