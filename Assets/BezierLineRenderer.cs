using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBezier;

public class BezierLineRenderer : MonoBehaviour
{
    Transform p0;
    [SerializeField] Transform p1;
    [SerializeField] Transform p2;
    private void OnDrawGizmos()
    {
        p0 = transform;

        Vector3 prev = p0.position;
        for (int i = 0; i < 30; i++)
        {
            float v = i / (30f - 1f);
            Vector3 p = Bezier.CalculateQuadraticBezierPoint(v, p0.position, p1.position, p2.position);

            Gizmos.DrawLine(prev, p);
            prev = p;

        }
    }
}
