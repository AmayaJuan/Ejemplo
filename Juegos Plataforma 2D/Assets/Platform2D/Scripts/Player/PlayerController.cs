using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]public bool grounded;
    public float maxSpeed = 5f;
    public float speed = 2f;
    public float jumpPower = 6.5f;

    private bool jump;
    private bool doubleJump;

    Animator anim;
    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (grounded)
            doubleJump = true;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2D.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
            rb2D.velocity = fixedVelocity;

        float h = Input.GetAxisRaw("Horizontal");
        rb2D.AddForce(Vector2.right * speed * h);
        float limitedSpeed = Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed);
        rb2D.velocity = new Vector2(limitedSpeed, rb2D.velocity.y);

        if (h > .1f)
            transform.localScale = new Vector3(1f, 1f, 1f);

        if (h < -.1f)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        if (jump)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }

    void OnBecameInvisible()
    {
        transform.position = new Vector3(-1, 0, 0);
    }
}
