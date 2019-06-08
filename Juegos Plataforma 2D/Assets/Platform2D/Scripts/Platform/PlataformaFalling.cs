using UnityEngine;

public class PlataformaFalling : MonoBehaviour
{
    public float fallDelay = 1f;
    public float respawnDelay = 5f;

    private PolygonCollider2D pc2D;
    private Vector3 start;

    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pc2D = GetComponent<PolygonCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall()
    {
        rb2D.isKinematic = false;
        pc2D.isTrigger = true;
    }

    void Respawn()
    {
        transform.position = start;
        rb2D.isKinematic = true;
        rb2D.velocity = Vector3.zero;
        pc2D.isTrigger = false;
    }
}
