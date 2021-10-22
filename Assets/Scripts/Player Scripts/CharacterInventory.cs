using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    #region References
    InputManager input;
    AnimationManager animManager;
    RigAnimEvents rigAnimEvents;
    CharacterEvents events;
    #endregion
    ///Handle Weapon Switching and track what weapons you got

    [SerializeField] Transform weaponFolder; //Transform which has all the weapon prefabs as children

    public List<Transform> weaponList = new List<Transform>();
    private int weaponIndex; //What weapon index you're currently on



    #region Unity Events
    private void Awake()
    {
        input = GetComponent<InputManager>();
        animManager = GetComponent<AnimationManager>();
        rigAnimEvents = GetComponentInChildren<RigAnimEvents>();
        events = GetComponent<CharacterEvents>();

        UpdateWeaponList();
        //SwitchWeapon(0);
    }

    private void Start()
    {
        SwitchWeapon(0);
    }

    private void Update()
    {
        if (input.switchDown)
        {
            weaponIndex++;
            weaponIndex = weaponIndex % weaponList.Count;
            SwitchWeapon(weaponIndex);
        }
    }
    #endregion

    #region Custom Methods
    public void UpdateWeaponList()
    {
        int childCount = weaponFolder.childCount;
        weaponList.Clear();

        for (int i = 0; i < childCount-1; i++)
            ///Make sure that the RigMesh is at the last spot in the weaponFolder
        {

            weaponList.Add(weaponFolder.GetChild(i).GetComponent<Transform>());
        }
        animManager.UpdateAnimators(weaponList);
    }

    public void SwitchWeapon(int _index)
    {
        if (_index < weaponList.Count)
        {
            for (int i = 0; i < weaponList.Count; i++)
            {
                weaponList[i].gameObject.SetActive(false);
            }
            weaponList[_index].gameObject.SetActive(true);
            animManager.SwitchAnimator(_index);
            rigAnimEvents.SwitchGun(weaponList[_index].gameObject);

            GunClip clip = weaponList[_index].GetComponent<GunClip>();
            //events.Invoke_OnWeaponSwitch(clip.magazineSize);
            events.OnWeaponSwitch(clip.magazineSize);
            //events.Invoke_OnMagazineChange(clip.ShotsInMag);
            events.OnMagazineChange(clip.ShotsInMag);
            
        }
        weaponIndex = _index;
    }

    #endregion

}
