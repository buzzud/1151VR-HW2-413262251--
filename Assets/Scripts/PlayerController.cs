
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 8f;

    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private CapsuleCollider2D playerCollider;
    private SpriteRenderer spriteRenderer;

    private float moveX;
    private bool wantToJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // A、D 或左右方向鍵控制移動
        moveX = 0f;

        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }

        if (Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }

        // 改變企鵝面對的方向
        if (moveX != 0)
        {
            spriteRenderer.flipX = moveX < 0;
        }

        // 按空白鍵，且站在地板上才能跳
        if (Input.GetKeyDown(KeyCode.Space) &&
            playerCollider.IsTouchingLayers(groundLayer))
        {
            wantToJump = true;
        }
    }

    void FixedUpdate()
    {
        // 使用 Vector2 控制左右移動
        rb.linearVelocity = new Vector2(
            moveX * moveSpeed,
            rb.linearVelocity.y
        );

        // 跳躍
        if (wantToJump)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpSpeed
            );

            wantToJump = false;
        }
    }
}
