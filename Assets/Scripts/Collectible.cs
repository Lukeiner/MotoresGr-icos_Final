using UnityEngine;
using System;

public class Collectible : SpawnableObject
{
    public static event Action<int> OnCollected;

    [Header("Ajustes del Recolectable")]
    [SerializeField] private int pointsValue = 50;

    [SerializeField] private float[] possibleYOffsets = new float[] { 0.4f, 1f, 2.5f };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke(pointsValue);
            gameObject.SetActive(false); 
        }
    }

    public override float GetYOffset()
    {
       
        if (possibleYOffsets != null && possibleYOffsets.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, possibleYOffsets.Length);
            return possibleYOffsets[randomIndex];
        }

        return base.GetYOffset();
    }
}
