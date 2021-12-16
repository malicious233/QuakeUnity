using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public float damageValue;
    public Vector3 knockbackDir;

    //I could add some Factory/Builder pattern to customize certain damage properties more nicely, such as knockback, damage types, etc...
    public Damage(float _damageValue, Vector3 _knockbackDir)
    {
        damageValue = _damageValue;
        knockbackDir = _knockbackDir;
    }
}
