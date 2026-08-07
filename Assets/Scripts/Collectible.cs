using UnityEngine;
using System;

public class Collectible : SpawnableObject
{
    public static event Action<int> OnCollected;

    [Header("Ajustes del Recolectable")]
    [SerializeField] private int pointsValue = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke(pointsValue);
            gameObject.SetActive(false); 
        }
    }
}
