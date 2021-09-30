using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public Transform camTransform;

    [Tooltip("Amount of 'time' shooting once will add to the recoil pattern")]
    ///Is added to patternTime
    public float recoilPerShot;

    [Tooltip("Amount of recoil lost per second when not firing")]
    public float patternRecoveryTime;

    [Tooltip("How long it takes for the camera to recover from recoil")]
    [Range(0,1)]
    public float recoilRecoveryTime;

    [Tooltip("Recoil pattern cap")]
    public float recoilPatternDuration;

    [Header("Horizontal Recoil:")]
    public AnimationCurve horizontalRecoilPattern;
    [Tooltip("Amplify all horizontal recoil by this multiplier")]
    public float horizontalRecoilMultiplier;

    [Header("Vertical Recoil:")]
    public AnimationCurve verticalRecoilPattern;
    [Tooltip("Amplify all vertical recoil by this multiplier")]
    public float verticalRecoilMultiplier;

    

    

    public float patternTime = 0;

    Quaternion recoilRotation;

    

    public void AddRecoil()
    {
        patternTime += recoilPerShot;
        patternTime = Mathf.Min(patternTime, recoilPatternDuration);
        
        recoilRotation = Quaternion.AngleAxis(horizontalRecoilPattern.Evaluate(patternTime) * horizontalRecoilMultiplier * Mathf.Deg2Rad, Vector3.up);
        recoilRotation *= Quaternion.AngleAxis(verticalRecoilPattern.Evaluate(patternTime) * verticalRecoilMultiplier * Mathf.Deg2Rad, -Vector3.right);

        //camTransform.localRotation *= recoilRotation;
    }



    private void GetRecoilFromPattern(out float _hori, out float _verti)
    {
        _hori = horizontalRecoilPattern.Evaluate(patternTime);
        _verti = verticalRecoilPattern.Evaluate(patternTime);
    }

    public void Awake()
    {

    }

    public void Update()
    {
        patternTime -= patternRecoveryTime * Time.deltaTime;
        patternTime = Mathf.Max(0, patternTime);
        camTransform.localRotation = Quaternion.Lerp(camTransform.localRotation, recoilRotation, 0.3f);
        recoilRotation = Quaternion.Lerp(recoilRotation, Quaternion.Euler(0, 0, 0), 0.01f);
        //camTransform.localRotation = Quaternion.Lerp(camTransform.localRotation, Quaternion.Euler(0, 0, 0), 0.01f);
    }

    
}
