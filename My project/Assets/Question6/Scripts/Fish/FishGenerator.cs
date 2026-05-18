using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int mapSize;
    [SerializeField] private NoiseSettings noiseSettings;
    [SerializeField] private bool autoUpdate;
    [SerializeField] private int seed;
    [SerializeField] private Vector2 offset;

    [SerializeField] private int maxNumberOfFishes = 100;
    [SerializeField] private Fish fishPrefab;

    private List<Fish> fishes = new List<Fish>();
    public List<Fish> Fishes { get => fishes; private set => fishes = value; }
    public bool AutoUpdate { get => autoUpdate; }

    private void Awake()
    {
        fishes.Clear();
        foreach (var fish in FindObjectsOfType<Fish>())
        {
            fishes.Add(fish);
        }
    }

    public void GenerateFishes()
    {
        DeleteFishes();
    }

    public void DeleteFishes()
    {
        foreach (Fish fish in fishes)
        {
            if (fish == null) { continue; }
            DestroyImmediate(fish.gameObject);
        }
        fishes.Clear();
    }

    private void OnValidate()
    {
        if (mapSize.y < 1) { mapSize.y = 1; }
        if (mapSize.x < 1) { mapSize.x = 1; }
        if (noiseSettings.lacunarity < 1) { noiseSettings.lacunarity = 1; }
        if (noiseSettings.octaves < 0) { noiseSettings.octaves = 0; }
    }
}