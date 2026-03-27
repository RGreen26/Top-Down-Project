using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spr;
    public float moveSpeed, jumpForce, sprintSpeed;
    public Rigidbody2D rb;
    public Animator anim;
    public float playerHeight;

    private int groundLayer = 6;
    private float horizontalInput;
    private float verticalInput;
    private bool canJump;

    void Start()
    {
        groundLayer = 1 << groundLayer;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump == true)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.position += Vector2.right * horizontalInput * sprintSpeed * Time.fixedDeltaTime;
            //Debug.Log("Sprinting");
            anim.SetBool("isRun", true);
        }
        else
        {
            rb.position += Vector2.right * horizontalInput * moveSpeed * Time.fixedDeltaTime;
            //Debug.Log("Walking");
            anim.SetBool("isRun", false);
        }

        if (horizontalInput < 0)
        {
            spr.flipX = true;
        }
        if (horizontalInput > 0)
        {
            spr.flipX = false;
        }
        
        if (horizontalInput != 0)
        {
            anim.SetBool("isWalk", true);
        }
        else 
        {
            anim.SetBool("isWalk", false);
        }

        //Detect if anything below player
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, playerHeight + 0.03f, groundLayer);

        if (hit)
        {
            canJump = true;
            Debug.Log(hit.transform.name);
        }

        else
        {
            Debug.Log("Nothing was hit");
            canJump = false;
        }
        
    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Ground")
    //     {
    //         canJump = true;
    //     }
    // }


    
}
