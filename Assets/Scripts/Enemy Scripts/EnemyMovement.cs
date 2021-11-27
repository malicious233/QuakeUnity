using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour, IMoveable
{
    CharacterController controller;
    EnemyEvents events;

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

    private void UpdateInputVector(Vector3 _inputVector)
    {
        inputVector = _inputVector;
    }
    public Vector3 UpdateVelocityGround(Vector3 _currentVelocity)
    {
        _currentVelocity = ApplyMovement(_currentVelocity, inputVector);
        _currentVelocity = Friction(_currentVelocity);
        _currentVelocity.y = 0;

        return _currentVelocity;
    }
    
    public Vector3 UpdateVelocityAir(Vector3 _currentVelocity)
    {
        _currentVelocity = ApplyGravity(_currentVelocity);
        return _currentVelocity;
    }

    Vector3 Friction(Vector3 _currentVelocity)
    {
        _currentVelocity -= _currentVelocity * deaccelSpeed * Time.deltaTime;
        return _currentVelocity;
    }

    Vector3 ApplyGravity(Vector3 _currentVelocity)
    {
        _currentVelocity.y -= gravity * Time.deltaTime;
        return _currentVelocity;
    }

    Vector3 ApplyMovement(Vector3 _currentVelocity, Vector3 _inputVector)
    {
        Vector3 speed2Add = _inputVector * movementSpeed ;
        _currentVelocity += speed2Add * Time.deltaTime;
        return _currentVelocity;
    }

    void RotateTowardsVelocity()
    {
        
    }
    #endregion


    #region Unity Methods
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        events = GetComponent<EnemyEvents>();
    }

    private void OnEnable()
    {
        events.OnUpdateMoveVector += UpdateInputVector; 
    }

    private void OnDisable()
    {
        events.OnUpdateMoveVector -= UpdateInputVector;
    }

    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            
            velocity = UpdateVelocityGround(velocity);
        }
        else
        {
            
            velocity = UpdateVelocityAir(velocity);
        }

        controller.Move(velocity * Time.deltaTime);
    }
    #endregion

}
