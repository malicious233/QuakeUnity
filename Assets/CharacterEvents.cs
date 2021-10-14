using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvents : MonoBehaviour
{
    public event Action<string> OnShoot;

    public void Invoke_OnShoot(string _string)
    {
        OnShoot?.Invoke(_string);
    }

}
