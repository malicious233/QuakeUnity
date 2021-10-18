using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GunFire fire;
    GunClip clip;
    GunFireRate fireRateComp;

    public Animator animator;

    private void Awake()
    {
        fire = GetComponent<GunFire>();
        clip = GetComponent<GunClip>();
        fireRateComp = GetComponent<GunFireRate>();
        animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        if (!fireRateComp.isAutomatic)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (fireRateComp.canFire && clip.canFire)
                {
                    fire.Shoot();
                }
            }
            
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (fireRateComp.canFire && clip.canFire)
                {
                    fire.Shoot();
                }
            }
        }
        
        
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            clip.ReloadClip();
        }
        */
    }
}
