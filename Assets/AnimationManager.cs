using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    CharacterEvents events;
    public Animator rigAnimator;
    public Animator gunAnimator;

    //Somehow do that it will add the respective gun name to the end of the name of the string that rigAnimator will play, once we get to adding more guns
    public void Awake()
    {
        events = GetComponent<CharacterEvents>();
    }
    public void PlayAnim(string _anim)
    {
        rigAnimator.Play(_anim, 0, 0);
        gunAnimator.Play(_anim, 0, 0);
    }

    public void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            events.Invoke_OnShoot("Shoot");
            //PlayAnim("Shoot");
        }
        */

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayAnim("Reload");
        }


    }

    public void OnEnable()
    {
        events.OnShoot += PlayAnim;
    }
}
