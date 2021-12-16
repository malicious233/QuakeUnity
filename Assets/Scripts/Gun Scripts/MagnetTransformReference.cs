using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new MagnetTransformReference")]
public class MagnetTransformReference : ScriptableObject
{
    
    public Transform magnetTransform;
    public bool isMagnetOut;
}
