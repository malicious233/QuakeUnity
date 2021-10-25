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
    }


}
