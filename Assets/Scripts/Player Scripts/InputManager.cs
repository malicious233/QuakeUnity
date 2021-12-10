using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    Camera cam;

    public float horizontalInputAxis;
    public float verticalInputAxis;
    public float mouseHorizontalInputAxis;
    public float mouseVerticalInputAxis;
    public bool jumpDown;
    public bool reloadDown;
    public bool switchDown;

    public bool ability1Down;
    public bool ability1Hold;
    public bool ability2Down;
    public bool ability2Hold;

    public bool crouchHold;

    public bool fireDown;
    public bool fireHold;
    public bool fireRelease;
    public bool altFireDown;

    public Vector3 inputVector;

    public void Update()
    {
        KeyCode fire = KeyCode.Mouse0;
        fireDown = Input.GetKeyDown(fire);
        fireHold = Input.GetKey(fire);
        fireRelease = Input.GetKeyUp(fire);

        altFireDown = Input.GetKeyDown(KeyCode.Mouse1);

        horizontalInputAxis = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        verticalInputAxis = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        jumpDown = Input.GetKeyDown(KeyCode.Space);
        reloadDown = Input.GetKeyDown(KeyCode.R);
        switchDown = Input.GetKeyDown(KeyCode.F);
        ability1Down = Input.GetKeyDown(KeyCode.Q);
        ability1Hold = Input.GetKey(KeyCode.Q);
        ability2Down = Input.GetKeyDown(KeyCode.E);
        ability2Hold = Input.GetKey(KeyCode.E);
        crouchHold = Input.GetKey(KeyCode.LeftControl);

        mouseHorizontalInputAxis = Input.GetAxis("Mouse X");
        mouseVerticalInputAxis = Input.GetAxis("Mouse Y");

        //inputVector = new Vector3(horizontalInputAxis, 0, verticalInputAxis);
        inputVector = transform.right * horizontalInputAxis + transform.forward * verticalInputAxis;
        inputVector.Normalize();

    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + inputVector);
    }
}
