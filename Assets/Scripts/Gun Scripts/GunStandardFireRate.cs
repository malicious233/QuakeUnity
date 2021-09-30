using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStandardFireRate : GunFireRate
{
    public float fireRate;
    private float timeUntilFireAgain;

    public override void StartFireInterval()
    {
        timeUntilFireAgain = fireRate;
        canFire = false;
        

    }

    public void Update()
    {
        timeUntilFireAgain -= Time.deltaTime;
        if (timeUntilFireAgain <= 0)
        {
            canFire = true;
        }
    }

}
