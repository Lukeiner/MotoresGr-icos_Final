using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    private float width;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        width = spriteRenderer.bounds.size.x;
    }
    void Update()
    { 
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        if (transform.position.x < -width)
        {
            Vector3 resetPosition = new Vector3(width * 2f, 0, 0);
            transform.position += resetPosition;
        }
    }
}
