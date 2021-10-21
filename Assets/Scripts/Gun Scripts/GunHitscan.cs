using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHitscan : GunFire
{
    public LayerMask layerMask;
    private GunParticles particles;

    [SerializeField] GunDamage shotDamage;

    public float range;

    [SerializeField] List<Pellet> pelletSpread;



    public override void Shoot()
    {
        base.Shoot();


        //particles.muzzleFlash.Emit(1);
        particles.muzzleFlash.Play();
        SpawnShot(camTransform.forward);
        foreach (var item in pelletSpread)
        {
            Vector3 shootDir = camTransform.forward;
            Quaternion thingX = Quaternion.AngleAxis(item.spreadX, camTransform.up);
            Quaternion thingY = Quaternion.AngleAxis(item.spreadY, camTransform.right);

            Vector3 result = thingX * thingY * shootDir;

            
            SpawnShot(result);
        }
        


    }

    void SpawnShot(Vector3 _shootDirection)
    {
        Vector3 tracerPoint;
        RaycastHit hit = GetHitPoint(_shootDirection);
        if (Physics.Raycast(camTransform.position, _shootDirection, out hit, range, layerMask))
        {
            var bulletHit = Instantiate(Instantiate(particles.bulletHitEffect, hit.point, Quaternion.identity));
            bulletHit.transform.forward = hit.normal;
            tracerPoint = hit.point;

        }
        else
        {
            tracerPoint = camTransform.forward * range;
        }

        particles.CreateTracer(tracerPoint);
    }

    public RaycastHit GetHitPoint(Vector3 _shotDirection)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _shotDirection, out hit, range, layerMask))
        {
            CharacterStats _stats = hit.transform.GetComponent<CharacterStats>();
            if (_stats != null)
            {
                _stats.InflictDamage(shotDamage.damageValue);
            }
            return hit;
        }
        return hit;

    }

    public Vector3 RotatePointAroundPivot(Vector3 _finalPosition, Vector3 _pivotPosition, Quaternion _finalRotation)
    {
        return _pivotPosition + (_finalRotation * (_finalPosition - _pivotPosition)); // returns new position of the point;
    }

    public override void Awake()
    {
        base.Awake();
        particles = GetComponent<GunParticles>();
    }

    [System.Serializable]
    public class Pellet
    {
        [Header("Spread in degrees")]
        public float spreadX;
        public float spreadY;

        public Pellet(float _spreadX, float _spreadY)
        {
            spreadX = _spreadX; //In degrees
            spreadY = _spreadY; //In degrees
            
        }

    }


}
