using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkDistance = 0.5f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private float flipCooldown = 0.2f;
    private float flipTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        flipTimer -= Time.deltaTime;

        CheckEdge();
    }

    void Move()
    {
        float direction = -transform.localScale.x; 
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    void CheckEdge()
    {
        if (flipTimer > 0) return;

        RaycastHit2D hit = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            checkDistance,
            groundLayer
        );

        if (!hit)
        {
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (flipTimer > 0) return;

        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(
            -transform.localScale.x,
            1,
            1
        );

        flipTimer = flipCooldown;
    }
}