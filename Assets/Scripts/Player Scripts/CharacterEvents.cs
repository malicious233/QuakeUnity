using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvents : MonoBehaviour
{
    public Action OnShoot;
    public Action OnFullMagazine;
    public Action<float> OnHealthChange; //Returns the amount of health you got left
    public Action<float> OnHealthChangePercentage; //Returns the percentage of health you have left
    public Action<int> OnMagazineChange;
    public Action<int> OnWeaponSwitch;

    /*
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

    public void Invoke_OnFullMagazine()
    {
        OnFullMagazine?.Invoke();
    }
    */

}
