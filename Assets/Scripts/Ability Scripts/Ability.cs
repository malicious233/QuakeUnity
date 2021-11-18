using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    InputManager input;

    private void Awake()
    {
        input = GetComponentInParent<InputManager>();
    }
}
