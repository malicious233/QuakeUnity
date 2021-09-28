using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GunFire fire;
    GunClip clip;

    private void Awake()
    {
        fire = GetComponent<GunFire>();
        clip = GetComponent<GunClip>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fire.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            clip.ReloadClip();
        }
    }
}
