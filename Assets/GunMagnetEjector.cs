using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMagnetEjector : MonoBehaviour
{
    InputManager input;

    [SerializeField] Transform magnetTransform;
    [SerializeField] float magnetFireDistance = 50f;

    private void Awake()  
    {
        input = GetComponentInParent<InputManager>();
    }

    private void Update()
    {
        if (input.altFireDown)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, magnetFireDistance, StaticVariables.groundMask))
            {
                PlaceMagnet(hit.point);
            }
        }
    }

    public void PlaceMagnet(Vector3 _position)
    {
        magnetTransform.parent = null;
        magnetTransform.position = _position;
    }
}
