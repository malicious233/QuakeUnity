using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    [SerializeField] Transform abilityFolder;

    public class AbilitySlot
    {
        public Transform abilityTransform;
        public IAbility Iability; //Iability doesnt even look like a real word

        public AbilitySlot(Transform _abilityTransform, IAbility _Iability)
        {
            abilityTransform = _abilityTransform;
            Iability = _Iability;
        }
    }
    public List<AbilitySlot> abilitySlots = new List<AbilitySlot>();

    InputManager input;
    CharacterInventory inventory;

    public void ActivateAbility()
    {
        
    }

    public void InactivateAbility()
    {

    }

    private void Awake()
    {
        input = GetComponent<InputManager>();
        inventory = GetComponent<CharacterInventory>();

        UpdateAbilitySlotList();
    }

    public void UpdateAbilitySlotList()
    {
        int childCount = abilityFolder.childCount;
        abilitySlots.Clear();

        for (int i = 0; i < childCount - 1; i++)
        ///Make sure that the RigMesh is at the last spot in the weaponFolder
        {
            Transform abilTransform = abilityFolder.GetChild(i).GetComponent<Transform>();
            IAbility iabil = abilTransform.GetComponent<IAbility>();
            AbilitySlot newSlot = new AbilitySlot(abilTransform, iabil);
            abilitySlots.Add(newSlot);
            //abilitySlots.Add(abilityFolder.GetChild(i).GetComponent<Transform>());
        }
    }
}
