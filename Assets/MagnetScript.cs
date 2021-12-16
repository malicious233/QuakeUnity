using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{

    MagnetMovement movement;

    


    private void Attach(Transform _transformToStick)
    {
        //transform.parent = _transformToStick;

    }

    public void InitializeMagnet(Vector3 _throwVelocity)
    {
        movement.OnThrowStart();
        movement.velocity = _throwVelocity;
    }

    private void Awake()
    {
        movement = GetComponent<MagnetMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Attach(collision.transform);
    }

    

    
}
