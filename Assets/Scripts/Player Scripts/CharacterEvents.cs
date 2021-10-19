using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvents : MonoBehaviour
{
    public event Action<string> OnShoot;
    public event Action<int> OnMagazineChange;
    public event Action<int> OnWeaponSwitch;

    public void Invoke_OnShoot(string _anim)
    {
        OnShoot?.Invoke(_anim);
    }

    public void Invoke_OnMagazineChange(int _shotsInMag)
    {
        OnMagazineChange?.Invoke(_shotsInMag);
    }

    public void Invoke_OnWeaponSwitch(int _magSize)
    {
        OnWeaponSwitch?.Invoke(_magSize);
    }

}
