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
        GameObject obj = ObjectPool.Instance.GetPooledObject();

        if (obj != null)
        {
            // Polimorfismo: No nos importa qué es exactamente, solo que sea un SpawnableObject
            SpawnableObject spawnable = obj.GetComponent<SpawnableObject>();

            float yPos = spawnPoint.position.y;
            if (spawnable != null)
            {
                yPos += spawnable.GetYOffset();
            }

            obj.transform.position = new Vector3(spawnPoint.position.x, yPos, spawnPoint.position.z);
            obj.transform.rotation = spawnPoint.rotation;
            obj.SetActive(true);
        }
    }
}
