using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputManager input;
    CharacterController charController;
    [SerializeField] Camera cam;
    [SerializeField] Transform eyePoint;

    public Vector3 velocity;
    public float current_Speed;
    private float xRotation;
    private float yRotation;
    private Vector3 rotOfCamera;

    
    [Header("Ground Stats:")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveDeaccel = 0.99f;
    
    [SerializeField] float max_Speed = 10f;
    [SerializeField] float accel_Speed = 7.5f;
    [SerializeField] float max_Accel = 10f;
    [SerializeField] float jumpHeight = 4f;

    [Header("Air Stats:")]
    [SerializeField] float airSpeed = 5f;

    [SerializeField] float max_AirSpeed = 9f;
    [SerializeField] float max_AirAccel = 8f;
    [SerializeField] float gravity = 3f;

    [SerializeField] float airControl = 0.3f;

    [Header("Control Settings:")]
    [SerializeField] float mouseSensitivity = 1f;

    public void Awake()
    {
        input = GetComponent<InputManager>();
        charController = GetComponent<CharacterController>();
    }

    public void Update()
    {
        if (charController.isGrounded)
        {
            UpdateVelocityGround();
            if (Input.GetKey(KeyCode.Space))
            {
                velocity.y = jumpHeight;
            }
        }
        else
        {
            UpdateVelocityAir();
            velocity.y -= gravity * Time.deltaTime;
        }

        RotateCamera();

        charController.Move(velocity);
    }

    public void RotateCamera()
    {
        
        
        
        xRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        //eyePoint.localRotation = Quaternion.AngleAxis(xRotation, Vector3.up);
        eyePoint.localRotation = Quaternion.AngleAxis(yRotation, Vector3.left);

        Quaternion combOffset = Quaternion.AngleAxis(xRotation, Vector3.up);

        transform.localRotation = combOffset;
        

        /*
        rotOfCamera.x -= mouseY;
        rotOfCamera.x = Mathf.Clamp(rotOfCamera.x, -90, 90);
        rotOfCamera.y += mouseX;
        rotOfCamera.z = 0;

        eyePoint.rotation = Quaternion.Euler(rotOfCamera);
        transform.localRotation = Quaternion.Euler(0, rotOfCamera.y, 0); //Gross! Euler
        */
        //cam.transform.position = eyePoint.transform.position;
        //cam.transform.rotation = eyePoint.transform.rotation;

    }

    public void UpdateVelocityGround()
    {
        velocity = Friction(velocity);

        current_Speed = Vector3.Dot(velocity, input.inputVector);
        float add_Speed = Mathf.Clamp(max_Speed - current_Speed * moveSpeed, 0, max_Accel); //Replace that final max-Speed with a real max-accel variable, also that moveSpeed variable is ill placed
        velocity = velocity + add_Speed * input.inputVector * Time.deltaTime;
    }

    public void UpdateVelocityAir()
    {
        //velocity = Friction(velocity);

        current_Speed = Vector3.Dot(velocity, input.inputVector);

        float add_Speed = Mathf.Clamp(max_AirSpeed - current_Speed * airSpeed, 0, max_AirAccel); //Replace that final max-Speed with a real max-accel variable, also that moveSpeed variable is ill placed
        velocity = velocity + add_Speed * input.inputVector * Time.deltaTime;
    }

    public Vector3 Friction(Vector3 _velocity)
    {
        _velocity -= _velocity * moveDeaccel * Time.deltaTime;
        return _velocity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + velocity);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 0, velocity.magnitude));
    }
}
