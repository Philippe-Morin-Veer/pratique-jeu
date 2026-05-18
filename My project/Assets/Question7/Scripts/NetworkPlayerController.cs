using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NetworkPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 16f;
    [SerializeField] private float maxY = 4.4f;
    [SerializeField] private float minY = -4.4f;

    private float movement = 0;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(new Vector2(
            rb.position.x,
            Mathf.Clamp(rb.position.y + movement * speed * Time.fixedDeltaTime, minY, maxY)
        ));
    }

    private void ProcessInputs()
    {
        movement = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
