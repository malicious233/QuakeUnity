using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class speedoMeter : MonoBehaviour
{
    public PlayerController player;
    TextMeshProUGUI text;

    public void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        float absVelocity;
        absVelocity = player.velocity.magnitude;
        absVelocity = Mathf.Abs(absVelocity);
        text.text = absVelocity.ToString();
    }

}
