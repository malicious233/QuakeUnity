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

        public static bool CurveRaycast(Vector3 p0, Vector3 p1, Vector3 p2, int _curveGranularity, LayerMask _layer, out RaycastHit _hit)
        {
            Vector3 prev = p0;
            for (int i = 0; i < _curveGranularity; i++)
            {
                float v = i / (_curveGranularity - 1f);
                Vector3 p = Bezier.CalculateQuadraticBezierPoint(v, p0, p1, p2);

                Vector3 dir = p - prev;
                float magni = (p - prev).magnitude;
                dir.Normalize();
                RaycastHit hit;
                if (Physics.Raycast(p, dir, out hit, magni, _layer))
                {
                    
                    _hit = hit;
                    return true;
                }
                //Instantiate(tst, prev, Quaternion.identity);
                prev = p;

            }
            _hit = new RaycastHit();
            return false;
        }


        public static bool CurveRaycast(Vector3 p0, Vector3 p1, Vector3 p2, int _curveGranularity, LayerMask _layer, out RaycastHit _hit, out Vector3[] linePositions)
        {
            Vector3 prev = p0;
            List<Vector3> _linePositionList = new List<Vector3>();

            for (int i = 0; i < _curveGranularity; i++)
            {
                
                float v = i / (_curveGranularity - 1f);
                Vector3 p = Bezier.CalculateQuadraticBezierPoint(v, p0, p1, p2);

                _linePositionList.Add(p);

                Vector3 dir = p - prev;
                float magni = (p - prev).magnitude;
                dir.Normalize();
                RaycastHit hit;
                if (Physics.Raycast(p, dir, out hit, magni, _layer))
                {
                    _linePositionList[i] = hit.point;
                    _linePositionList.Reverse();
                    linePositions = _linePositionList.ToArray();
                    _hit = hit;
                    return true;
                }
                //Instantiate(tst, prev, Quaternion.identity);
                prev = p;

            }
            _hit = new RaycastHit();
            _linePositionList.Reverse();
            linePositions = _linePositionList.ToArray();
            
            return false;
        }
    }

    
}
