using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMagazine : GunClip
{
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
            shotsInMag = h;
        }
    }
    

    public override void AffectClip()
        ///Simply reduces shots in mag by one upon firing
    {
        ShotsInMag--;
        if (ShotsInMag == 0)
        {
            canFire = false;
        }
    }

    public override void ReloadClip()
    {
        ShotsInMag = magazineSize;
    }

    public void Start()
    {
        ShotsInMag = magazineSize;
        canFire = true;
    }

}
