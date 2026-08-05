using UnityEngine;

public enum ObstacleType { Low, Medium, High }

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float xBound = -10f;

    [Header("Tipo de Obstáculo")]
    public ObstacleType type;

    [SerializeField] private float yOffset = 0f;

    private bool isMoving = true;

    private void OnEnable()
    {
        PlayerController.OnPlayerDied += StopMoving;
        isMoving = true;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= StopMoving;
    }

    private void Update()
    {
        if (!isMoving) return;

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < xBound)
        {
            gameObject.SetActive(false);
        }
    }

    private void StopMoving()
    {
        isMoving = false;
    }

    public float GetYOffset()
    {
        return yOffset;
    }
}
