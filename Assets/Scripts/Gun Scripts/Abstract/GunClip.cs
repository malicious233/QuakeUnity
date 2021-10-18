using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunClip : MonoBehaviour
{
    public bool canFire;

    CharacterEvents events;

    public int magazineSize;

    public int shotsInMag;
    public int ShotsInMag
    {
        get
        {
            return shotsInMag;
        }
        set
        {
            int h = Mathf.Clamp(value, 0, magazineSize);
            if (h != 0)
            {
                canFire = true;
            }
            events.Invoke_OnMagazineChange(h);
            shotsInMag = h;
        }
    }


    public void AffectClip()
    ///Simply reduces shots in mag by one upon firing
    {
        ShotsInMag--;
        if (ShotsInMag == 0)
        {
            canFire = false;
        }
    }

    public void ReloadClip()
    {
        ShotsInMag = magazineSize;
    }

    public void Start()
    {
        ShotsInMag = magazineSize;
        canFire = true;
    }

    public void Awake()
    {
        events = GetComponentInParent<CharacterEvents>();
    }
}
