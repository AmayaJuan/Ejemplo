using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

    private float maxSpeed = 5f;

    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rb2D.AddForce(Vector2.right * speed * h);

        if (rb2D.velocity.x > maxSpeed)
            rb2D.velocity = new Vector2(maxSpeed, rb2D.velocity.x);

        if (rb2D.velocity.x < -maxSpeed)
            rb2D.velocity = new Vector2(-maxSpeed, rb2D.velocity.x);
    }
}
