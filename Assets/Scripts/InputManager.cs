using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Camera cam;

    public float horizontalInputAxis;
    public float verticalInputAxis;

    public float mouseHorizontalInputAxis;

    public Vector3 inputVector;
    public void Update()
    {
        horizontalInputAxis = Input.GetAxisRaw("Horizontal");
        verticalInputAxis = Input.GetAxisRaw("Vertical");

        mouseHorizontalInputAxis = Input.GetAxis("Mouse X");

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
