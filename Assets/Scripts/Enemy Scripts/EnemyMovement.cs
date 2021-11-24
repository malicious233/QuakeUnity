using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour, IMoveable
{
    CharacterController controller;
    public Vector3 velocity;
    public Vector3 inputVector;

    [Header("STATS:")]
    [SerializeField] float gravity;
    [SerializeField] float movementSpeed;
    [SerializeField] float deaccelSpeed;

    public Vector3 Velocity
    {
        get
        {
            return velocity;
        }
        set
        {
            velocity = value;
        }
    }

    #region Custom Methods
    public Vector3 UpdateVelocityGround(Vector3 _currentVelocity)
    {
        _currentVelocity = Friction(_currentVelocity);
        //_currentVelocity.y = 0;
        return _currentVelocity;
    }
    
    public Vector3 UpdateVelocityAir(Vector3 _currentVelocity)
    {
        
        return _currentVelocity;
    }

    Vector3 Friction(Vector3 _currentVelocity)
    {
        _currentVelocity -= _currentVelocity * deaccelSpeed * Time.deltaTime;
        return _currentVelocity;
    }

    Vector3 ApplyGravity(Vector3 _currentVelocity)
    {
        _currentVelocity.y -= gravity;
        return _currentVelocity;
    }
    #endregion


    #region Unity Methods
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            
            velocity = UpdateVelocityGround(velocity);
        }
        else
        {
            velocity = ApplyGravity(velocity);
            velocity = UpdateVelocityAir(velocity);
        }

        controller.Move(velocity * Time.deltaTime);
    }
    #endregion

}
