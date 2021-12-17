using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IMoveable
{
    InputManager input;
    CharacterController charController;
    [SerializeField] Transform eyePoint;

    [SerializeField] Vector3Var velocityVar;
    //public Vector3 velocity;
    public float current_Speed;
    private float xRotation;
    private float yRotation;


    [Header("Ground Stats:")]
    [SerializeField] float maxGroundSpeed = 5f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveDeaccel = 0.99f;
    
    [SerializeField] float max_Accel = 10f;
    [SerializeField] float jumpHeight = 4f;

    [Header("Air Stats:")]
    [SerializeField] float maxAirSpeed = 5f;
    [SerializeField] float airSpeed = 5f;

    [SerializeField] float max_AirAccel = 8f;
    [SerializeField] float gravity = 3f;

    

    [Header("Control Settings:")]
    [SerializeField] float mouseSensitivity = 1f;

    public Vector3 Velocity
    {
        get
        {
            return velocityVar.Value;
        }
        set
        {
            velocityVar.Value = value;
        }
    }

    public void Awake()
    {
        input = GetComponent<InputManager>();
        charController = GetComponent<CharacterController>();
    }

    public void FixedUpdate()
    {
        
        if (charController.isGrounded)
        {
            //velocity = UpdateVelocityGround(velocity);
            Velocity = UpdateVelocityGround(Velocity);
            if (Input.GetKey(KeyCode.Space))
            {
                Velocity += new Vector3(0, jumpHeight, 0);
            }
        }
        else
        {
            Velocity = UpdateVelocityAir(Velocity);
            Velocity -= new Vector3(0, gravity * Time.deltaTime, 0);
        }

        
        
        charController.Move(Velocity * Time.deltaTime * 60);

        

        
    }

    public void Update()
    {
        RotateCamera();
    }

    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Velocity -= hit.normal * Vector3.Dot(Velocity, hit.normal);
    }
    


    public void RotateCamera()
    {
        xRotation += input.mouseHorizontalInputAxis * mouseSensitivity ;
        yRotation += input.mouseVerticalInputAxis * mouseSensitivity;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        eyePoint.localRotation = Quaternion.AngleAxis(yRotation, Vector3.left);

        transform.localRotation = Quaternion.AngleAxis(xRotation, Vector3.up);
        
    }

    public Vector3 UpdateVelocityGround(Vector3 _velocity)
    {
        _velocity = Friction(_velocity);

        current_Speed = Vector3.Dot(input.inputVector, _velocity);
        
        float add_Speed = Mathf.Clamp(maxGroundSpeed - current_Speed * moveSpeed, 0, maxGroundSpeed); //Replace that final max-Speed with a real max-accel variable, also that moveSpeed variable is ill placed
        
        return _velocity + (add_Speed * input.inputVector) * Time.deltaTime;
    }

    public Vector3 UpdateVelocityAir(Vector3 _velocity)
    {
        //velocity = Friction(velocity);

        current_Speed = Vector3.Dot(input.inputVector, _velocity);
        float add_Speed = Mathf.Clamp(maxAirSpeed - current_Speed * airSpeed, 0, maxAirSpeed); //Replace that final max-Speed with a real max-accel variable, also that moveSpeed variable is ill placed
        
        return _velocity + (add_Speed * input.inputVector) * Time.deltaTime;
    }

    public Vector3 Friction(Vector3 _velocity)
        ///Returns a frictioned value of inputted velocity dhaakd
    {
        _velocity -= _velocity * moveDeaccel * Time.deltaTime;
        return _velocity;
    }

    public Vector3 ReduceVelocityOnCollision(Vector3 _velocity)
        ///Halts velocity incase your collider is colliding with something
    {
        return _velocity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Velocity);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 0, Velocity.magnitude));
    }
}
