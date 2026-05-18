using UnityEngine;

public class NetworkSpawner : MonoBehaviour
{
    [SerializeField] private NetworkEnemy enemyPrefab;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private float x = 10;
    [SerializeField] private float maxY = 4.5f;
    [SerializeField] private float minY = -4.5f;

    private float remainingCooldown = 0;

    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        remainingCooldown -= Time.deltaTime;
        if (remainingCooldown > float.Epsilon) { return; }
        remainingCooldown = cooldown;

        Instantiate(enemyPrefab, new Vector3(x, Random.Range(minY, maxY), 0), Quaternion.identity);
    }
}
