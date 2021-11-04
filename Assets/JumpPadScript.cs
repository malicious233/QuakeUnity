using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    [SerializeField] float jumpForce;


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("yo");
    }
}
