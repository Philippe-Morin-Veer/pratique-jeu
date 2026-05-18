using UnityEngine;

public class NetworkBullet : MonoBehaviour
{
    [SerializeField] private float speed = 21f;

    private Vector3 movement = Vector3.zero;

    private void Update()
    {
        movement = transform.right * speed * Time.deltaTime;
        Move();
    }

    private void Move()
    {
        transform.position += movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
