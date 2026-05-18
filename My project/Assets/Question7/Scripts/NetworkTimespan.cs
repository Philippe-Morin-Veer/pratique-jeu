using System.Collections;
using UnityEngine;

public class NetworkTimespan : MonoBehaviour
{
    [SerializeField] private float lifespan = 2f;

    private void Awake()
    {
        StartCoroutine(Timeout());
    }

    private IEnumerator Timeout()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
