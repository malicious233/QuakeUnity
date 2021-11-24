using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    Vector3 Velocity
    {
        get;
        set;
    }

    Vector3 UpdateVelocityGround(Vector3 _currentVelocity);
    Vector3 UpdateVelocityAir(Vector3 _currentVelocity);
}
