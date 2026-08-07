using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private GameObject[] obstaclePreFab;
    [SerializeField] private int poolSize = 12;

    private List<GameObject> poolList = new List<GameObject>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewPooledObject();
        }
    }
    private GameObject CreateNewPooledObject()
    {
        if (obstaclePreFab.Length == 0)
        {
            Debug.LogError("¡No asignaste prefabs en el array 'obstaclePrefabs'!");
            return null;
        }
        int randomIndex = Random.Range(0, obstaclePreFab.Length);
        GameObject obj = Instantiate(obstaclePreFab[randomIndex]);

        obj.SetActive(false);
        poolList.Add(obj);
        return obj;
    }
    public GameObject GetPooledObject ()
    {
        List<GameObject> availableObjects = new List<GameObject>();

        for (int i = 0; i < poolList.Count; i++)
        {
            if (!poolList[i].activeInHierarchy)
            {
                availableObjects.Add(poolList[i]);
            }
        }
        if (availableObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, availableObjects.Count);
            return availableObjects[randomIndex];
        }
        return CreateNewPooledObject();
    }
}
