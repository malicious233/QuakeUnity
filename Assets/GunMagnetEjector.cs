using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunMagnetEjector : MonoBehaviour
{
    InputManager input;
    MagnetScript magnet;

    [SerializeField] GameObject magnetPrefab;
    [SerializeField] MagnetTransformReference magnetTransformReference;

    //[SerializeField] Transform magnetTransform;
    [SerializeField] float magnetFireDistance = 50f;

    [SerializeField] FloatRef magnetThrowStrength;

    public bool isMagnetOut;

    private void Awake()  
    {
        input = GetComponentInParent<InputManager>();
        NewMagnet();
    }



    private void Update()
    {
        if (input.altFireDown)
        {

            if (magnetTransformReference.isMagnetOut)
            {
                Debug.Log("Throw");
                ThrowMagnet(transform.forward);
            }
            else
            {
                Debug.Log("Recall");
                RecallMagnet();
            }
            
        }
    }

    public void ReturnMagnet()
    {
        isMagnetOut = false;
        Debug.Log("gone");
    }

    public void PlaceMagnet(Vector3 _position)
    {
        Transform tr = magnetTransformReference.magnetTransform;

        tr.parent = null;
        tr.position = _position;
    }

    public void ThrowMagnet(Vector3 _direction)
    {
        magnetTransformReference.isMagnetOut = true;

        Transform tr = magnetTransformReference.magnetTransform;
        
        tr.gameObject.SetActive(true);
        tr.parent = null;

        magnetTransformReference.magnetTransform.position = transform.position;
        Vector3 throwVelocity = transform.forward * magnetThrowStrength.Value;

        magnet.InitializeMagnet(throwVelocity);


    }

    public void RecallMagnet()
    {
        magnetTransformReference.isMagnetOut = false;
    }

    public void NewMagnet()
    {
        magnetTransformReference.isMagnetOut = true;

        GameObject newMagnet = Instantiate(magnetPrefab);
        magnetTransformReference.magnetTransform = newMagnet.transform;
        magnet = newMagnet.GetComponent<MagnetScript>();
        
        //magnetTransform = _newTransform;
    }
}
