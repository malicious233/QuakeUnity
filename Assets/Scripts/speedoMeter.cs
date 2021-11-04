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
        Vector3 newVector = new Vector3(player.velocity.x, 0, player.velocity.z);
        float absVelocity;
        absVelocity = newVector.magnitude;
        absVelocity = Mathf.Abs(absVelocity);
        text.text = absVelocity.ToString();
    }

}
