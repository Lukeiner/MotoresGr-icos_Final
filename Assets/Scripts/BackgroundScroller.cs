using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    private float width;

    void Start()
    {
        // Medimos el ancho exacto usando el SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        width = spriteRenderer.bounds.size.x;
    }
    void Update()
    {   // Desplazamos la posición en X hacia la izquierda según el tiempo del frame
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        // Si sobrepasa su propio ancho a la izquierda, se teletransporta a la derecha
        if (transform.position.x < -width)
        {
            Vector3 resetPosition = new Vector3(width * 2f, 0, 0);
            transform.position += resetPosition;
        }
    }
}
