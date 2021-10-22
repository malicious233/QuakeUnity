using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public float damageValue;
    public Vector3 knockbackDir;

    public Damage(float _damageValue, Vector3 _knockbackDir)
    {
        damageValue = _damageValue;
        knockbackDir = _knockbackDir;
    }
}
