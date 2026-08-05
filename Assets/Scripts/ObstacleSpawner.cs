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
        GameObject obstacleObj = ObjectPool.Instance.GetPooledObject();

        if (obstacleObj != null)
        {
            Obstacle obstacle = obstacleObj.GetComponent<Obstacle>();

            // Posición base del Spawner + la altura propia que pide el obstáculo
            Vector3 spawnPosition = new Vector3(
                spawnPoint.position.x,
                spawnPoint.position.y + obstacle.GetYOffset(),
                spawnPoint.position.z);

            obstacleObj.transform.position = spawnPosition;
            obstacleObj.transform.rotation = spawnPoint.rotation;
            obstacleObj.SetActive(true);
        }
    }
}
