using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunClip : MonoBehaviour
{
    public bool canFire;

    CharacterEvents events;


    public int magazineSize;

    [Tooltip("Wether or not this gun reloads bullets one by one")]
    [SerializeField] bool slugReload;

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
            if (slugReload && h >= magazineSize)
            {
                //events.Invoke_OnFullMagazine();
                events.OnFullMagazine.Invoke();
            }
            events.OnMagazineChange.Invoke(h);
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

    public void ReloadAmount(int _amount)
    {
        ShotsInMag += _amount;
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
