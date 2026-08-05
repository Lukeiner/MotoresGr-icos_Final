using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private GameObject[] obstaclePreFab;
    [SerializeField] private int poolSize = 3;

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

        // Elegimos un prefab al azar entre las opciones (Bajo, Medio, Alto)
        int randomIndex = Random.Range(0, obstaclePreFab.Length);
        GameObject obj = Instantiate(obstaclePreFab[randomIndex]);

        obj.SetActive(false);
        poolList.Add(obj);
        return obj;
    }

    public GameObject GetPooledObject ()
    {
        for (int i = 0; i < poolList.Count; i++)
        {
            if (!poolList[i].activeInHierarchy)
            {
                return poolList[i];
            }
        }

        // Si se nos agotaron los desactivados, creamos uno nuevo sobre la marcha
        return CreateNewPooledObject();
    }
}
