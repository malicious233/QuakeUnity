using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHold : Gun
{
    

    [SerializeField] float intervalBetweenShot;
    float currIntervalBetweenShot;
    [SerializeField] float intervalBetweenBurst;
    float currIntervalBetweenBurst;
    [SerializeField] int burstAmount;
    int burstsLeft;

    bool bursting = false;

    private void Start()
    {
        currIntervalBetweenBurst = intervalBetweenBurst;
        burstsLeft = burstAmount;
    }
    public override void Update()
    {
        currIntervalBetweenShot = currIntervalBetweenShot - Time.deltaTime;
        Debug.Log(currIntervalBetweenBurst);
        currIntervalBetweenBurst = currIntervalBetweenBurst - Time.deltaTime;

        if (input.fireRelease)
        {
            if (clip.canFire && currIntervalBetweenBurst < 0)
            {
                bursting = true;
               
                
            }
        }

        if (currIntervalBetweenShot <= 0 && bursting && clip.canFire)
        {
            currIntervalBetweenShot = intervalBetweenShot;
            burstsLeft--;
            fire.Shoot();
        }

        if (burstsLeft <= 0)
        {
            currIntervalBetweenBurst = intervalBetweenBurst;
            burstsLeft = burstAmount;
            bursting = false;
        }
    }
}
