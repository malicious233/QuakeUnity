using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetMovement : MonoBehaviour, IMoveable
{

    [SerializeField] FloatRef gravity;
    [SerializeField] FloatRef stickDuration;

    MagnetScript magnet;
    Transform attachedToTransform;

    public bool isAttached = false;
    public bool isAttachedToCharacter = false;
    public bool canStickToCharacter;

    private float currStickDuration;

    public Vector3 velocity;
    public Vector3 Velocity { get => velocity; set { velocity = value; } }

    private void Awake()
    {
        MagnetScript magnet = GetComponent<MagnetScript>();
    }

    private void Update()
    {
        if (!isAttached)
        {
            CheckAttach();
            AddGravity();
            transform.position += velocity * Time.deltaTime;
            
            
        }
        else
        {
            

            if (isAttachedToCharacter)
            {

                if (currStickDuration < 0 || attachedToTransform == null)
                {
                    Unstick();
                }
                else
                {
                    currStickDuration -= Time.deltaTime;
                    transform.position = attachedToTransform.position;
                }
                
            }

        }
        
    }

    private void AddGravity()
    {
        velocity.y -= gravity.Value * Time.deltaTime;
    }

    public void AddVelocity(Vector3 _velocity)
    {
        velocity += _velocity;
    }

    public void CheckAttach()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, 0.2f, StaticVariables.hurtboxMask);

        if (canStickToCharacter)
        {
            
            if (col.Length > 0)
            {
                Debug.Log("HIIIT");
                attachedToTransform = col[0].GetComponent<Transform>();
                isAttached = true;
                isAttachedToCharacter = true;
                currStickDuration = stickDuration.Value;
                return;
            }
        }
        

        col = Physics.OverlapSphere(transform.position, 0.2f, StaticVariables.groundMask);
        if (col.Length > 0)
        {
            Debug.Log("HIIITGROUND");
            isAttached = true;
            attachedToTransform = null;
        }
    }

    public void Unstick()
    {
        isAttached = false;
        isAttachedToCharacter = false;
        velocity = Vector3.zero;
        canStickToCharacter = false;
    }

    public void OnThrowStart()
    {
        isAttached = false;
        isAttachedToCharacter = false;
        canStickToCharacter = true;
    }


}
