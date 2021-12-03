using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public PoolManager poolManager;

    private void OnDisable()
    {
        if (poolManager != null)
        {
            poolManager.ReturnObject(this.gameObject);
        }

    }
}
