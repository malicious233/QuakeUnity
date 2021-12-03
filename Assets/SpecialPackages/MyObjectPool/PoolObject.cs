using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public PoolManager poolManager;
    public bool isTrackedByPool = true;
    private void OnDisable()
    {
        if (!isTrackedByPool)
        {
            Debug.Log("bye");
            Destroy(gameObject);
            return;
        }
        if (poolManager != null)
        {
            poolManager.ReturnObject(this.gameObject);
        }

    }
}
