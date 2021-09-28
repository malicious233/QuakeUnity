using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunClip : MonoBehaviour
{
    public bool canFire;

    public virtual void AffectClip() 
        ///Method which affects the clip, is called when gun fires
    {

    }

    public virtual void ReloadClip()
        ///Method which is called when you try to reload
    {

    }
}
