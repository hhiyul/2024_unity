using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class char_move : MonoBehaviour
{
    public string main;
    public string gameover;

    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 170.0f;
//  float walkForce = 10.0f;
    float maxWalkSpeed = 5.0f;
    

    public int maxJumpCount = 2;
    public int jumpCount = 0;
    bool isInWall = false;
    bool isGrounded = false;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        isInWall = IsInWall();
        isGrounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (isInWall && jumpCount < maxJumpCount - 1)
            {
                Jump();
            }
            else if (!isInWall)
            {
                Jump();
            }
        }

        if (isGrounded)
        {
            jumpCount = 0;
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) key = 1;
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) key = -1;

        this.rigid2D.velocity = new Vector2(key * maxWalkSpeed, this.rigid2D.velocity.y);

     /*  float speedx = Mathf.Abs(this.rigid2D.velocity.x); 


        if (!IsInAir())
        {
            if (speedx < this.maxWalkSpeed)
            {
                this.rigid2D.velocity = new Vector2(key * maxWalkSpeed, this.rigid2D.velocity.y);
            }
        }
        else
        {
            if (key != 0)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }
            else
            {
                this.rigid2D.velocity = new Vector2(key * maxWalkSpeed, this.rigid2D.velocity.y);
            }
        }
*/
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("gameover");
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Vector2 normal = contact.normal;

            if (normal.y > 0.5f)
            {
                jumpCount = 0;
                break;
            }
        }
     /*   if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
            rigid2D.velocity = Vector2.zero; 

        }*/
        
    }

    bool IsInAir()
    {
        return Mathf.Abs(rigid2D.velocity.y) > 0.01f;
    }

    void Jump()
    {
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
        rigid2D.AddForce(Vector2.up * jumpForce);
        jumpCount++;
    }

    bool IsInWall()
    {
        float rayLength = 0.1f;
        LayerMask wallLayer = LayerMask.GetMask("Wall");
        return Physics2D.Raycast(transform.position, Vector2.left, rayLength, wallLayer) ||
               Physics2D.Raycast(transform.position, Vector2.right, rayLength, wallLayer);
    }

    bool IsGrounded()
    {
        float rayLength = 0.1f;
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        return Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
    }
    
}
