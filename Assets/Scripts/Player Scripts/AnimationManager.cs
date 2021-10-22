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
    public void PlayAnimUninterrupted(string _anim)
    {
        rigAnimator.Play(_anim, 0, 0);
        gunAnimator.Play(_anim, 0, 0);
    }

    public void PlayAnim(string _anim)
    {
        rigAnimator.Play(_anim);
        gunAnimator.Play(_anim);
    }

    public void UpdateAnimators(List<Transform> _weaponList)
    {
        rigAnimators.Clear();
        for (int i = 0; i < _weaponList.Count; i++)
        {
            rigAnimators.Add(_weaponList[i].GetComponentInChildren<GunAnimatorManager>().rigAnim);
        }
    }

    public void SetTriggers(string _boolName)
        //Sets triggers for both rig and gun
    {

        rigAnimator.SetTrigger(_boolName);
        gunAnimator.SetTrigger(_boolName);
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

    #region Dumb Methods
    void SetReloadDoneTriggers()
    {
        SetTriggers("ReloadDone");
    }
    #endregion

    void PlayShootAnim()
    {
        PlayAnimUninterrupted("Shoot");
    }

    public void OnEnable()
    {
        events.OnShoot += PlayShootAnim;
        events.OnFullMagazine += SetReloadDoneTriggers;
    }

    public void OnDisable()
    {
        events.OnShoot -= PlayShootAnim;
        events.OnFullMagazine -= SetReloadDoneTriggers;
    }
}
