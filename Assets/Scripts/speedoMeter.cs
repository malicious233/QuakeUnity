using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class speedoMeter : MonoBehaviour
{
    [SerializeField] Vector3Var playerVelocityVar;
    TextMeshProUGUI text;

    public void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        Vector3 newVector = new Vector3(playerVelocityVar.Value.x, 0, playerVelocityVar.Value.z);
        float absVelocity;
        absVelocity = newVector.magnitude;
        absVelocity = Mathf.Abs(absVelocity);
        text.text = absVelocity.ToString();
    }

}
