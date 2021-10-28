using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD_ShotsInMag : MonoBehaviour
{
    CharacterEvents events;
    TextMeshProUGUI shotsLeftText;
    [SerializeField] TextMeshProUGUI magSizeText;

    private void Awake()
    {
        events = FindObjectOfType<CharacterEvents>();
        shotsLeftText = GetComponent<TextMeshProUGUI>();
    }

    public void OnEnable()
    {
        events.OnMagazineChange += SetShotsInMagazine;
        events.OnWeaponSwitch += SetMagazineSize;
    }

    public void OnDisable()
    {
        events.OnMagazineChange -= SetShotsInMagazine;
        events.OnWeaponSwitch -= SetMagazineSize;
    }

    public void SetShotsInMagazine(int _value)
    {
        shotsLeftText.text = _value.ToString();
    }

    public void SetMagazineSize(int _value)
    {
        magSizeText.text = _value.ToString();
    }
}
