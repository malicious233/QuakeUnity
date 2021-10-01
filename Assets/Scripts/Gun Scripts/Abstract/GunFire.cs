using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunFire : MonoBehaviour
{
    private GunClip clip;
    private GunFireRate gunFireRate;
    private GunRecoil recoil;
    protected Transform camTransform;


    public virtual void Shoot()
        ///Method for when the gun fires
    {
        clip.AffectClip();
        gunFireRate.StartFireInterval();
        recoil.AddRecoil();

        
        
    }

    public virtual void Awake()
    {
        clip = GetComponent<GunClip>();
        gunFireRate = GetComponent<GunFireRate>();
        recoil = GetComponent<GunRecoil>();
        camTransform = Camera.main.transform;
    }
}
