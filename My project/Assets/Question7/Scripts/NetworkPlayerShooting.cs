using UnityEngine;

public class NetworkPlayerShooting : MonoBehaviour
{
    [SerializeField] private NetworkBullet bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float cooldown = 0.2f;

    private float isShooting = 0;
    private float remainingCooldown = 0;

    void Update()
    {
        ProcessInputs();
        Shoot();
    }

    private void Shoot()
    {
        remainingCooldown -= Time.deltaTime;
        if (isShooting <= float.Epsilon || remainingCooldown > float.Epsilon) { return; }

        remainingCooldown = cooldown;
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    private void ProcessInputs()
    {
        isShooting = Input.GetAxisRaw("Fire1");
    }
}
