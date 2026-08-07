using UnityEngine;

public abstract class SpawnableObject : MonoBehaviour
{
    [Header("Ajustes Base de Spawn")]
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float xBound = -10f;
    [SerializeField] protected float yOffset = 0f;
    protected bool isMoving = true;
    protected virtual void OnEnable()
    {
        PlayerController.OnPlayerDied += StopMoving;
        isMoving = true;
    }

    protected virtual void OnDisable()
    {
        PlayerController.OnPlayerDied -= StopMoving;
    }
    protected virtual void Update()
    {
        if (!isMoving) return;

        // Desplazamiento común hacia la izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Se desactiva solo si sale de la pantalla
        if (transform.position.x < xBound)
        {
            gameObject.SetActive(false);
        }
    }
    public float GetYOffset()
    {
        return yOffset;
    }
    protected virtual void StopMoving()
    {
        isMoving = false;
    }
}
