using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunFireRate : MonoBehaviour
{
    public bool canFire;
    public bool isAutomatic;

    public virtual void StartFireInterval()
    {

    }
}
