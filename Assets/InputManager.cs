using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float horizontalInputAxis;
    public float verticalInputAxis;
    public Vector3 inputVector;
    public void Update()
    {
        horizontalInputAxis = Input.GetAxisRaw("Horizontal");
        verticalInputAxis = Input.GetAxisRaw("Vertical");
        inputVector = new Vector3(horizontalInputAxis, 0, verticalInputAxis);
        inputVector.Normalize();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + inputVector);
    }
}
