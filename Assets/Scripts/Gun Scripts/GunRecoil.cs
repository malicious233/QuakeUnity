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
    float currRecoilRecoveryTime;

    [Tooltip("How long it takes for the camera to react to recoil")]
    public float recoilReactionTime = 0.3f;
    float currRecoilReactionTime = 0;
    float timeSinceShot = 0;

    [Tooltip("Recoil pattern cap")]
    public float recoilPatternDuration;

    [Header("Horizontal Recoil:")]
    public AnimationCurve horizontalRecoilPattern;
    [Tooltip("Amplify all horizontal recoil by this multiplier")]
    public float horizontalRecoilMultiplier;

    [Header("Random Horizontal Recoil:")]
    public AnimationCurve randomHoriRecoil;
    public float randomHoriRecoilMultiplier;

    [Header("Vertical Recoil:")]
    public AnimationCurve verticalRecoilPattern;
    [Tooltip("Amplify all vertical recoil by this multiplier")]
    public float verticalRecoilMultiplier;

    

    

    public float patternTime = 0;
    bool fired;

    Quaternion recoilRotation;

    

    public void AddRecoil()
    {
        patternTime += recoilPerShot;
        patternTime = Mathf.Min(patternTime, recoilPatternDuration);
        float horiRecoilAmount = horizontalRecoilPattern.Evaluate(patternTime) * horizontalRecoilMultiplier + Random.Range(-randomHoriRecoil.Evaluate(patternTime), randomHoriRecoil.Evaluate(patternTime)) * randomHoriRecoilMultiplier;
        
        recoilRotation = Quaternion.AngleAxis(horiRecoilAmount * Mathf.Deg2Rad, Vector3.up);
        recoilRotation *= Quaternion.AngleAxis(verticalRecoilPattern.Evaluate(patternTime) * verticalRecoilMultiplier * Mathf.Deg2Rad, -Vector3.right);
        currRecoilReactionTime = 0;
        timeSinceShot = 0;

        fired = true;
        //camTransform.localRotation *= recoilRotation;
    }






    public void LateUpdate()
    {
        
        patternTime -= patternRecoveryTime * Time.deltaTime;
        patternTime = Mathf.Max(0, patternTime);
        camTransform.localRotation = Quaternion.Lerp(camTransform.localRotation, recoilRotation, recoilReactionTime * Time.deltaTime * 60);
        recoilRotation = Quaternion.Lerp(recoilRotation, Quaternion.Euler(0, 0, 0), recoilRecoveryTime * Time.deltaTime * 60);
        
        //It is the recoilReactionTime and recoilRecoveryTimes that are faulty here
        //Might also move this onto another script so the gun itself doesnt directly control the camera

        //This right here is experimental code
        /*
        patternTime -= patternRecoveryTime * Time.deltaTime;
        patternTime = Mathf.Max(0, patternTime);

        timeSinceShot += Time.deltaTime;
        if (currRecoilReactionTime < recoilReactionTime)
        {
            //currRecoilReactionTime += Time.deltaTime * 0.9f;
            currRecoilReactionTime = Mathf.Pow(timeSinceShot, 1.6f * Time.deltaTime*60f);
            float t = currRecoilReactionTime / recoilReactionTime;
            //T here you can do the fuckin Freya animation curve thingamajig. Get at it!
            camTransform.localRotation = Quaternion.Lerp(camTransform.localRotation, recoilRotation, t);
            currRecoilRecoveryTime = 0;
        }

        //currRecoilRecoveryTime += Time.deltaTime * 1.1f;
        //currRecoilRecoveryTime = timeSinceShot * 0.3f * (Time.deltaTime * 60);
        currRecoilRecoveryTime = Mathf.Pow(timeSinceShot, 1.6f * Time.deltaTime * 60f);
        float f = currRecoilRecoveryTime / recoilRecoveryTime;
        Debug.Log(f);
        camTransform.localRotation = Quaternion.Lerp(camTransform.localRotation, Quaternion.Euler(0, 0, 0), f);
        */
        //Experimental code ends here


    }

}
