using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_HealthDisplay : MonoBehaviour
{
    Slider slider;
    CharacterEvents playerevents;


    private void Awake()
    {
        slider = GetComponent<Slider>();
        playerevents = FindObjectOfType<CharacterEvents>();
    }

    public void OnEnable()
    {
        playerevents.OnHealthChangePercentage += UpdateHPDisplay;
    }

    public void OnDisable()
    {
        playerevents.OnHealthChangePercentage -= UpdateHPDisplay;
    }

    private void UpdateHPDisplay(float _health)
    {
        slider.value = _health;
    }
}
