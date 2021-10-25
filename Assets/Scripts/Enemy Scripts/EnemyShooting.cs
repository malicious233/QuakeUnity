using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    EnemyEvents events;


    public void FireBullet(Vector3 _shootDirection)
    {
        GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        BulletMovement bul = obj.GetComponent<BulletMovement>();
        bul.moveDirection = _shootDirection;

    }

    public void Awake()
    {
        events = GetComponent<EnemyEvents>();
    }

    public void OnEnable()
    {
        events.Shoot += FireBullet;
    }

    public void OnDisable()
    {
        events.Shoot -= FireBullet;
    }
}
