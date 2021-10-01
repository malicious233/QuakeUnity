using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParticles : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletHitEffect;
    public TrailRenderer tracerEffect;
    public Transform bulletSpawnPoint;
    private Transform camTransform;

    public void CreateTracer(Vector3 hitPosition)
    {
        var tracer = Instantiate(tracerEffect, bulletSpawnPoint.position, Quaternion.identity);
        tracer.AddPosition(bulletSpawnPoint.position);
        tracer.transform.position = hitPosition;
    }

    public void Awake()
    {
        camTransform = Camera.main.transform;
    }
}
