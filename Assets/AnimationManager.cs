using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    CharacterEvents events;
    public Animator rigAnimator;
    public Animator gunAnimator;
    CharacterInventory inventory;

    public List<RuntimeAnimatorController> rigAnimators;

    public void Awake()
    {
        events = GetComponent<CharacterEvents>();
        inventory = GetComponent<CharacterInventory>();
    }
    public void PlayAnim(string _anim)
    {
        rigAnimator.Play(_anim, 0, 0);
        gunAnimator.Play(_anim, 0, 0);
    }

    public void UpdateAnimators(List<Transform> _weaponList)
    {
        rigAnimators.Clear();
        for (int i = 0; i < _weaponList.Count; i++)
        {
            rigAnimators.Add(_weaponList[i].GetComponentInChildren<GunAnimatorManager>().rigAnim);
        }
    }

    public void SwitchAnimator(int _index)
    {
        rigAnimator.runtimeAnimatorController = rigAnimators[_index];
        gunAnimator = inventory.weaponList[_index].GetComponentInChildren<Animator>();
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayAnim("Reload");
        }


    }

    public void OnEnable()
    {
        events.OnShoot += PlayAnim;
    }

    public void OnDisable()
    {
        events.OnShoot -= PlayAnim;
    }
}
