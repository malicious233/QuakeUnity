using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3;
    [SerializeField] float lifeTime = 3;
    public Vector3 moveDirection;

    public void FixedUpdate()
    {
        Vector3 movDir = moveDirection * moveSpeed;
        transform.position += movDir * Time.deltaTime;

        if (Physics.CheckSphere(transform.position, 0.1f, StaticVariables.groundMask))
        {
            EndBullet();
        }
    }

    public void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            EndBullet();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        EndBullet();
    }

    private void EndBullet()
    //Destroys the bullet. Might fit more advanced behavior in the future
    {
        
        Destroy(gameObject);
    }


}
