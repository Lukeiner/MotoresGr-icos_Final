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
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < xBound)
        {
            gameObject.SetActive(false);
        }
    }
    public virtual float GetYOffset()
    {
        return yOffset;
    }
    protected virtual void StopMoving()
    {
        isMoving = false;
    }
}
