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
    public bool reloadDown;
    public bool switchDown;
    public bool ability1Down;
    public bool ability2Down;

    public Vector3 inputVector;

    public void Update()
    {
        horizontalInputAxis = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        verticalInputAxis = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        reloadDown = Input.GetKeyDown(KeyCode.R);
        switchDown = Input.GetKeyDown(KeyCode.F);
        ability1Down = Input.GetKeyDown(KeyCode.Q);
        ability2Down = Input.GetKeyDown(KeyCode.E);
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
