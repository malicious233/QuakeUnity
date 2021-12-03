using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParticles : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    //public ParticleSystem bulletHitEffect;
    public TrailRenderer tracerEffect;
    public Transform bulletSpawnPoint;
    private Transform camTransform;

    [SerializeField] PoolManager bulletHitPool;

    public void CreateTracer(Vector3 hitPosition)
    {
        //Make this badboy be a pool
        var tracer = Instantiate(tracerEffect, bulletSpawnPoint.position, Quaternion.identity);
        tracer.AddPosition(bulletSpawnPoint.position);
        tracer.transform.position = hitPosition;
    }

    public Transform CreateBulletHit(Vector3 hitPosition)
    {
        GameObject obj = bulletHitPool.GetObject();
        obj.transform.position = hitPosition;
        return obj.transform;
    }
    public void Awake()
    {
        camTransform = Camera.main.transform;
    }
}
