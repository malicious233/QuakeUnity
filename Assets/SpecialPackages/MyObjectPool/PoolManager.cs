using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject poolPrefab;
    [SerializeField] private Queue<GameObject> objectPool = new Queue<GameObject>();
    [SerializeField] int poolStartSize = 5;

    private void Start()
    {

        for (int i = 0; i < poolStartSize; i++)
        {
            Debug.Log("boop");
            GameObject poolObject = Instantiate(poolPrefab);
            objectPool.Enqueue(poolObject);

            poolObject.SetActive(false);

            PoolObject poolObjComponent = poolObject.AddComponent<PoolObject>();
            poolObjComponent.poolManager = this;
        }


    }

    public GameObject GetObject()
    {
        if (objectPool.Count > 0)
        {
            
            GameObject poolObject = objectPool.Dequeue();
            poolObject.SetActive(true);
            return poolObject;
        }
        else
        {
            //Bad solution which means that you instantiate new things when exceeding the pool! 
            //Means that if this object only disables itself, not destroys, it will linger until the scene resets
            //Maybe try doing that you extend the pool temporarily, somehow.
            Debug.Log("POOL EXCEEDED. CREATING NEW OBJECT");
            GameObject poolObject = Instantiate(poolPrefab);
            PoolObject poolObjComponent = poolObject.AddComponent<PoolObject>();
            poolObjComponent.isTrackedByPool = false;
            return poolObject;
        }
    }

    public void ReturnObject(GameObject _poolObject)
    {
        objectPool.Enqueue(_poolObject);
        _poolObject.SetActive(false);
    }
}
