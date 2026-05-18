using System;
using UnityEngine;

public class MovementGenerator : MonoBehaviour
{
    [SerializeField] private FishGenerator fishGenerator;

    [SerializeField] private Vector2Int mapSize;
    [SerializeField] private NoiseSettings noiseSettings;
    [SerializeField] private bool autoUpdate;
    [SerializeField] private int seed;
    [SerializeField] private Vector2 offset;

    [SerializeField] private float force = 3f;

    [SerializeField] private float timeBeforeUpdate = 5f;
    private float remainingTimeBeforeUpdate = 0;

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        foreach (Fish fish in fishGenerator.Fishes)
        {
            // Code pour le mouvement des poissons
        }

        remainingTimeBeforeUpdate -= Time.fixedDeltaTime;
        if (remainingTimeBeforeUpdate > float.Epsilon)
        {
            remainingTimeBeforeUpdate = timeBeforeUpdate;
            // Code pour nouveau mouvement
        }
    }

    private void OnValidate()
    {
        if (mapSize.y < 1) { mapSize.y = 1; }
        if (mapSize.x < 1) { mapSize.x = 1; }
        if (noiseSettings.lacunarity < 1) { noiseSettings.lacunarity = 1; }
        if (noiseSettings.octaves < 0) { noiseSettings.octaves = 0; }
    }
}