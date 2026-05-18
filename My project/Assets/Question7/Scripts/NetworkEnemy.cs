using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.2f;
    [SerializeField] private ParticleSystem explosion;

    private Vector3 movement = Vector3.zero;

    private void Update()
    {
        movement = -transform.right * speed * Time.deltaTime;
        Move();
    }

    private void Move()
    {
        transform.position += movement;
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();
        Destroy(gameObject);
    }
}

