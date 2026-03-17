using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spr;
    public float moveSpeed;
    public Rigidbody2D rb;

    public Sprite LookRightImage;
    public Sprite lookUpImage;

    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.position += Vector2.right * horizontalInput * moveSpeed * Time.fixedDeltaTime;
        rb.position += Vector2.up * verticalInput * moveSpeed * Time.fixedDeltaTime;
        
        if (horizontalInput < 0)
        {
            spr.sprite = LookRightImage;
            spr.flipX = true;
        }
        if (horizontalInput > 0)
        {
            spr.sprite = LookRightImage;
            spr.flipX = false;
        }
        
         if (verticalInput < 0)
        {
            spr.sprite = lookUpImage;
            spr.flipY = true;
        }
        if (verticalInput > 0)
        {
            spr.sprite = lookUpImage;
            spr.flipY = false;
        }
    }
}
