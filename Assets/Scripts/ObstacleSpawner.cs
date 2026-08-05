using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private Transform spawnPoint;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = ObjectPool.Instance.GetPooledObject();

        if (obstacle != null )
        {
            obstacle.transform.position = spawnPoint.position;
            obstacle.transform.rotation = spawnPoint.rotation;
            obstacle.SetActive(true);
        }
    }
}
