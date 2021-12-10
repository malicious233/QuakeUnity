using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    protected GunFire fire;
    protected GunClip clip;
    protected GunFireRate fireRateComp;
    protected InputManager input;

    //public Animator animator;

    private void Awake()
    {
        fire = GetComponent<GunFire>();
        clip = GetComponent<GunClip>();
        fireRateComp = GetComponent<GunFireRate>();
        //animator = GetComponentInChildren<Animator>();
        input = GetComponentInParent<InputManager>();
    }

    public virtual void Update()
    {
        if (!fireRateComp.isAutomatic)
        {
            if (input.fireDown) 
            {
                if (fireRateComp.canFire && clip.canFire)
                {
                    fire.Shoot();
                }
            }
            
        }
        else
        {
            if (input.fireHold)
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
