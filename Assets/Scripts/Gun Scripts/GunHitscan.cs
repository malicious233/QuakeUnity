using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHitscan : GunFire
{
    public LayerMask layerMask;
    public GameObject pref;

    [SerializeField] GunDamage shotDamage;

    public float range;

    public override void Shoot()
    {
        base.Shoot();

        Debug.Log("bang!");
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, range, layerMask);


        Instantiate(pref, hit.point, Quaternion.identity);
    }


}
