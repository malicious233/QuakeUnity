using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigAnimEvents : MonoBehaviour
{
    private GunClip clip;

    public void Awake()
    {
        //clip = GetComponentInParent<GunClip>();
    }

    public void SwitchGun(GameObject _gam)
    {
        clip = _gam.GetComponent<GunClip>();
    }

    public void Reload()
    {
        clip.ReloadClip();
    }

    public void ReloadAmount(int _amount)
    {
        clip.ReloadAmount(_amount);
    }
}
