using UnityEngine;
using System;

public class DistanceTracker : MonoBehaviour
{
    public static event Action<int> OnDistanceUpdated;

    [Header("Ajustes")]

    private float currentDistance = 0f;
    private bool isTracking = false;

    private void OnEnable()
    {
        PlayerController.OnPlayerDied += StopTracking;

        isTracking = true;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= StopTracking;
    }

    private void Update()
    {
        if (!isTracking) return;

        currentDistance +=  Time.deltaTime;
        OnDistanceUpdated?.Invoke(Mathf.FloorToInt(currentDistance));
    }

    private void AddBonusDistance(int bonusMeters)
    {
        currentDistance += bonusMeters;
        OnDistanceUpdated?.Invoke(Mathf.FloorToInt(currentDistance));
    }

    private void StopTracking()
    {
        isTracking = false;
    }

    public int GetFinalDistance()
    {
        return Mathf.FloorToInt(currentDistance);
    }
    
}
