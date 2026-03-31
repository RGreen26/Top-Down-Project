using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public SpriteRenderer spr;
    public float moveSpeed;
    public Rigidbody2D rb;
    public DoorOpen data;

    public Sprite LookRightImage;
    public Sprite lookUpImage;

    private float horizontalInput;
    private float verticalInput;

    public int KeyCollected;
    private int PlayerLayer = 7;

    private Vector2 playerDirection;

    void Start()
    {
        PlayerLayer = 1 << PlayerLayer;
        PlayerLayer = ~PlayerLayer;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
         if (horizontalInput < 0)
        {
            spr.sprite = LookRightImage;
            spr.flipX = true;
            playerDirection = Vector2.left;
        }
        if (horizontalInput > 0)
        {
            spr.sprite = LookRightImage;
            spr.flipX = false;
            playerDirection = Vector2.right;
        }
        
         if (verticalInput < 0)
        {
            spr.sprite = lookUpImage;
            spr.flipY = true;
            playerDirection = Vector2.down;
        }
        if (verticalInput > 0)
        {
            spr.sprite = lookUpImage;
            spr.flipY = false;
            playerDirection = Vector2.up;
        }

        rb.position += Vector2.right * horizontalInput * moveSpeed * Time.fixedDeltaTime;
        rb.position += Vector2.up * verticalInput * moveSpeed * Time.fixedDeltaTime;
        
        
         RaycastHit2D hit = Physics2D.Raycast(rb.position, playerDirection, 3f, PlayerLayer);

        if (hit && Input.GetKey(KeyCode.F) && KeyCollected == 4)
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Door" && data.CanDestroy == true)
            {
                Destroy(hit.transform.gameObject);
            }
        }

        else
        {
            Debug.Log("Nothing was hit");
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Key")
        {
            KeyCollected += 1;

            //other.gameObject.SetActive(false);

            Destroy(other.gameObject);
        }
    }
}
