using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputManager input;
    CharacterController charController;
    public Camera cam;

    public Vector3 velocity;
    public float current_Speed;
    private float xRotation;
    
    [Header("Movement Stats:")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveDeaccel = 0.99f;
    [SerializeField] float airControl = 0.3f;
    [SerializeField] float max_Speed = 10f;
    [SerializeField] float max_Accel = 10f;
    [SerializeField] float jumpHeight = 4f;
    [SerializeField] float gravity = 3f;

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
        float mouseX = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(0f, xRotation * -1, 0f);
        transform.Rotate(Vector3.up * mouseX);

        cam.transform.position = gameObject.transform.position;
        cam.transform.rotation = gameObject.transform.rotation;
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
        float add_Speed = Mathf.Clamp(max_Speed - current_Speed * moveSpeed, 0, max_Accel); //Replace that final max-Speed with a real max-accel variable, also that moveSpeed variable is ill placed
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
