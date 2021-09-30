using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunFire : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    private GunClip clip;
    private GunFireRate gunFireRate;
    private GunRecoil recoil;


    public virtual void Shoot()
        ///Method for when the gun fires
    {
        muzzleFlash.gameObject.SetActive(true);
        clip.AffectClip();
        gunFireRate.StartFireInterval();
        recoil.AddRecoil();
    }

    private void Awake()
    {
        clip = GetComponent<GunClip>();
        gunFireRate = GetComponent<GunFireRate>();
        recoil = GetComponent<GunRecoil>();
    }
}
