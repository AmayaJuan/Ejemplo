using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PlayerController player;

    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        rb2D = GetComponentInParent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            rb2D.velocity = Vector3.zero;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            player.grounded = true;

        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = collision.transform;
            player.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            player.grounded = false;

        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
