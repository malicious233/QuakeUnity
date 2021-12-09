using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBezier
{
    public class Bezier
    {
        public static Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            Vector3 p = uu * p0;
            p += 2 * u * t * p1;
            p += tt * p2;


            return p;
        }
    }
}
