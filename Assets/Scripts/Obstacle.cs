using UnityEngine;

public enum ObstacleType { Low, Medium, High }

public class Obstacle : SpawnableObject
{
    [Header("Ajustes del Obstáculo")]
    public ObstacleType type;

}
