using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Application.targetFrameRate = 10;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Application.targetFrameRate = 200;
        }
    }

}
