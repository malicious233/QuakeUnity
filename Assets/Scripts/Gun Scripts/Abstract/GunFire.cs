using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    private GunClip clip;

    public virtual void Shoot()
        ///Method for when the gun fires
    {
        clip.AffectClip();
    }

    private void Awake()
    {
        clip = GetComponent<GunClip>();
    }
}
